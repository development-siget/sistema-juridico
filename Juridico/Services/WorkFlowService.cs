using System;
using System.Linq;
using Juridico.Data;
using Juridico.Extensions;
using Juridico.Models;
using Juridico.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Services
{
    public class WorkFlowService : IWorkFlowService
    {
        private readonly JuridicoDbContext _context;

        public WorkFlowService(JuridicoDbContext context)
        {
            _context = context;
        }

        public bool AgregarEstado(AccionCorrespondenciaViewModel accionCorrespondenciaViewModel)
        {
            // Se carga la acción que se realizó junto a la correspondencia a afectar.
            var accion = _context.Acciones.AsNoTracking()
                .First(a => a.Id == accionCorrespondenciaViewModel.AccionId);
            var correspondencia = _context.Correspondencias
                .First(c => c.Id == accionCorrespondenciaViewModel.CorrespondenciaId);
            // Se trae el estado anterior si existe
            var estadoActual = _context.HistoricoEstados
                .FirstOrDefault(he => he.CorrespondenciaId == correspondencia.Id && he.Activo);
            if (estadoActual != null)
            {
                estadoActual.FechaFin = DateTime.Now;
                estadoActual.Activo = false;
            }
            // Se trae el estado siguiente
            var estadoSiguiente = _context.Estados.First(e => e.Id == accion.EstadoSiguienteId);
            // 
            var historicoEstado = new HistoricoEstados()
            {
                CorrespondenciaId = correspondencia.Id,
                EstadoId = estadoSiguiente.Id,
                AccionId = accion.Id,
                FechaInicio = DateTime.Now,
                Activo = true,
                ComentarioAccion = accionCorrespondenciaViewModel.Comentario,
                NombreUsuarioCreador = accionCorrespondenciaViewModel.NombreUsuario,
            };
            // Si el estado tiene plazo de vencimiento se agrega la fecha al histórico de estado.
            if (estadoSiguiente.DiasPlazo.HasValue)
            {
                historicoEstado.FechaVencimiento = DateTime.Now.AddWorkDays(estadoSiguiente.DiasPlazo.Value, _context);
            }
            // Se actualiza la correspondencia con el nuevo estado
            correspondencia.EstadoActualId = estadoSiguiente.Id;
            _context.HistoricoEstados.Add(historicoEstado);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw new Exception($"Error de la aplicación. No se pudo guardar en la base de datos.");
            }
            return true;
        }
    }
}