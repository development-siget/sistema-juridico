using System;
using System.Linq;
using Juridico.Data;

namespace Juridico.Services
{
    public class CorrespondienciaService : ICorrespondenciaService
    {
        private readonly JuridicoDbContext _context;

        public CorrespondienciaService(JuridicoDbContext context)
        {
            _context = context;
        }

        public string GerenarCodigo()
        {
            var totalCorrespondencia = _context.Correspondencias
                .Where(c => c.FechaIngreso.Year == DateTime.Now.Year)
                .Select(c => c.Id)
                .Count();
            totalCorrespondencia++;
            var correlativo = $"{DateTime.Now.Year}-{totalCorrespondencia.ToString().PadLeft(4, '0')}";
            return correlativo;
        }
    }
}