using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juridico.Data;
using Juridico.Models;
//using Juridico.Helpers;
//using static Juridico.Helpers.ModalHelper;
using Juridico.ViewModels;
//using System.Web.Mvc;
using AutoMapper;

namespace Juridico.Controllers
{
    public class CorrespondenciaController : Controller
    {
        private readonly JuridicoDbContext _context;
        private readonly IMapper _mapper;

        public CorrespondenciaController(JuridicoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Correspondencia
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.Correspondencias.Include(c => c.EstadoActual).Include(c => c.PersonaPresento).Include(c => c.Proceso).Include(c => c.Regional).Include(c => c.Remitente);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: Correspondencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondencia = await _context.Correspondencias
                .Include(c => c.EstadoActual)
                .Include(c => c.PersonaPresento)
                .Include(c => c.Proceso)
                .Include(c => c.Regional)
                .Include(c => c.Remitente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correspondencia == null)
            {
                return NotFound();
            }

            return View(correspondencia);
        }

        // GET: Correspondencia/Create
        public IActionResult Create()
        {

            var anexos = _context.Anexos.ToList();
            var anexosvm = new List<Anexo>();

            foreach (var item in anexos)
            {
                anexosvm.Add(new Anexo()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                });

            }

            var correspondenciavm = new CorrespondenciaViewModel
            {
                Anexos = anexosvm,
            };

            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo");
            ViewData["PersonaPresentoId"] = new SelectList(_context.Personas, "Id", "Apellidos");
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo");
            ViewData["RegionalId"] = new SelectList(_context.Regionales, "Id", "Codigo");
            ViewData["RemitenteId"] = new SelectList(_context.Remitentes, "Id", "NombreRemitente");

            return View(correspondenciavm);


        }





        public IActionResult Prueba()
        {
            //var anexos = _context.Anexos.ToList();
            //return View(anexos);


            ViewData["Anexos"] = new SelectList(_context.Anexos, "Id", "Nombre");
            return View();
        }


        // GET: Correspondencia/IngresarCorrespondencia

        public IActionResult IngresarCorrespondencia(int? PersonaPresentoId)
        {
            var correspondenciavm = new CorrespondenciaViewModel
            {
                FechaIngreso = DateTime.Now,
                //Anexos = anexosvm,
                //Remitentes = remitentesvm,
                //Personas = personas,
            };

            if (PersonaPresentoId != null)
            {
                correspondenciavm.PersonaPresentoId = PersonaPresentoId.Value;
                
            }

            GetUltimaPersona();

            CargarDatos(PersonaPresentoId);
            //ViewData["Remitentes"] = new SelectList(remitentesvm, "Id", "NombreRemitente");
            //ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            return View(correspondenciavm);
        }

        private void CargarDatos(int? PersonaPresentoId)
        {
            var anexos = _context.Anexos.ToList();
            var anexosvm = new List<Anexo>();

            foreach (var item in anexos)
            {
                anexosvm.Add(new Anexo()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                });

            }

            var remitentes = _context.Remitentes.ToList();
            var remitentesvm = new List<Remitente>();
            foreach (var item in remitentes)
            {
                remitentesvm.Add(new Remitente()
                {
                    Id = item.Id,
                    NombreRemitente = item.NombreRemitente,

                });
            }



            if (PersonaPresentoId != null)
            {
                var personas = _context.Personas.Select(x => new Persona
                {
                    Id = x.Id,
                    Nombres = $"{x.Dui} - {x.Nombres} {x.Apellidos}"
                })
                    .Where(p => p.Id == PersonaPresentoId)
                    .ToList();
                ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            }
            else
            {
                var personas = _context.Personas.Select(x => new Persona
                {
                    Id = x.Id,
                    Nombres = $"{x.Dui} - {x.Nombres} {x.Apellidos}"
                }).ToList();
                ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            }


            ViewData["Remitentes"] = new SelectList(remitentesvm, "Id", "NombreRemitente");
            //ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            ViewData["Anexos"] = new SelectList(anexosvm, "Id", "Nombre");
            ViewData["TipoRemitente"] = new SelectList(_context.TiposRemitente, "Id", "Nombre");
            ViewData["TipoEntidad"] = new SelectList(_context.TiposContacto, "Id", "Nombre");
            ViewData["TipoDocumento"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente");

        }

        private void GetUltimaPersona() 
        {
            var personas = _context.Personas.Select(x => new Persona
            {
                Id = x.Id,
                Nombres = $"{x.Dui} - {x.Nombres} {x.Apellidos}"
            }).OrderByDescending(x=>x.Id).Take(1);

            ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
        }



        // POST: Correspondencia/IngresarCorrespondencia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IngresarCorrespondencia(CorrespondenciaViewModel correspondenciavm)
        {
            //[Bind("Id,Codigo,Referencia,Objeto,FechaIngreso,FechaDocumento,FechaFinalizacion,EstadoActualId,IngresadoPorId,RemitenteId,PersonaPresentoId,RegionalId,ProcesoId")]
            if (ModelState.IsValid)
            {
                _context.Add(correspondenciavm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", correspondenciavm.EstadoActualId);
            ViewData["PersonaPresentoId"] = new SelectList(_context.Personas, "Id", "Apellidos", correspondenciavm.PersonaPresentoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", correspondenciavm.ProcesoId);
            ViewData["RegionalId"] = new SelectList(_context.Regionales, "Id", "Codigo", correspondenciavm.RegionalId);
            ViewData["RemitenteId"] = new SelectList(_context.Remitentes, "Id", "NombreRemitente", correspondenciavm.RemitenteId);


            return View(correspondenciavm);
        }


        // POST: Correspondencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Referencia,Objeto,FechaIngreso,FechaDocumento,FechaFinalizacion,EstadoActualId,IngresadoPorId,RemitenteId,PersonaPresentoId,RegionalId,ProcesoId")] Correspondencia correspondencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correspondencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", correspondencia.EstadoActualId);
            ViewData["PersonaPresentoId"] = new SelectList(_context.Personas, "Id", "Apellidos", correspondencia.PersonaPresentoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", correspondencia.ProcesoId);
            ViewData["RegionalId"] = new SelectList(_context.Regionales, "Id", "Codigo", correspondencia.RegionalId);
            ViewData["RemitenteId"] = new SelectList(_context.Remitentes, "Id", "NombreRemitente", correspondencia.RemitenteId);
            return View(correspondencia);
        }

        // GET: Correspondencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondencia = await _context.Correspondencias.FindAsync(id);
            if (correspondencia == null)
            {
                return NotFound();
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", correspondencia.EstadoActualId);
            ViewData["PersonaPresentoId"] = new SelectList(_context.Personas, "Id", "Apellidos", correspondencia.PersonaPresentoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", correspondencia.ProcesoId);
            ViewData["RegionalId"] = new SelectList(_context.Regionales, "Id", "Codigo", correspondencia.RegionalId);
            ViewData["RemitenteId"] = new SelectList(_context.Remitentes, "Id", "NombreRemitente", correspondencia.RemitenteId);
            return View(correspondencia);
        }

        // POST: Correspondencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Referencia,Objeto,FechaIngreso,FechaDocumento,FechaFinalizacion,EstadoActualId,IngresadoPorId,RemitenteId,PersonaPresentoId,RegionalId,ProcesoId")] Correspondencia correspondencia)
        {
            if (id != correspondencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correspondencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorrespondenciaExists(correspondencia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", correspondencia.EstadoActualId);
            ViewData["PersonaPresentoId"] = new SelectList(_context.Personas, "Id", "Apellidos", correspondencia.PersonaPresentoId);
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", correspondencia.ProcesoId);
            ViewData["RegionalId"] = new SelectList(_context.Regionales, "Id", "Codigo", correspondencia.RegionalId);
            ViewData["RemitenteId"] = new SelectList(_context.Remitentes, "Id", "NombreRemitente", correspondencia.RemitenteId);
            return View(correspondencia);
        }

        // GET: Correspondencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondencia = await _context.Correspondencias
                .Include(c => c.EstadoActual)
                .Include(c => c.PersonaPresento)
                .Include(c => c.Proceso)
                .Include(c => c.Regional)
                .Include(c => c.Remitente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correspondencia == null)
            {
                return NotFound();
            }

            return View(correspondencia);
        }

        // POST: Correspondencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correspondencia = await _context.Correspondencias.FindAsync(id);
            _context.Correspondencias.Remove(correspondencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorrespondenciaExists(int id)
        {
            return _context.Correspondencias.Any(e => e.Id == id);
        }


        //Get
        public async Task<IActionResult> AgregarRemitente(int id = 0)
        {
            if (id == 0)
                return View(new Remitente());
            else
            {
                var remitente = await _context.Remitentes.FindAsync(id);
                if (remitente == null)
                {
                    return NotFound();
                }
                return View(remitente);
            }
        }

        //Get
        public async Task<IActionResult> AgregarPersona(int id=0)
        {
            if (id == 0)
                return View(new Persona());
            else
            {
                var persona = await _context.Personas.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }
                return View(persona);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult AgregarPersona(CorrespondenciaViewModel correspondenciavm)
        public IActionResult AgregarPersona(CorrespondenciaViewModel correspondenciavm)
        {
            //if (ModelState.IsValid)
            //{
            /* 
             if (correspondenciavm != null)
             {
               
            };
                 
             }
            */
                var datosPersona = new Persona
                {
                    Nombres = correspondenciavm.PersonaPresento.Nombres,
                    Apellidos = correspondenciavm.PersonaPresento.Apellidos,
                    Dui = correspondenciavm.PersonaPresento.Dui,
                    OtroDocumento = correspondenciavm.PersonaPresento.OtroDocumento,
                    Direccion = correspondenciavm.PersonaPresento.Direccion,
                    Telefono = correspondenciavm.PersonaPresento.Telefono,
                    Email = correspondenciavm.PersonaPresento.Email,
                };

            
          
            //  var datosPersona= _mapper.Map<Persona>(personavm);
                _context.Personas.Add(datosPersona);
                _context.SaveChanges();

                correspondenciavm.PersonaPresentoId = datosPersona.Id;
                return RedirectToAction(nameof(IngresarCorrespondencia), new { id = datosPersona.Id });
            //}
            //V= correspondenciavm.PersonaPresentoId = correspondenciavm.PersonaPresento.Id
           // return View(correspondenciavm);
        }

            /*
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AgregarRemitente([Bind("Id,NombreRemitente,NumeroDocumento,TipoDocumentoRemitenteId,Direccion,Telefono,Email,TipoEntidadId,TipoRemitenteId")] Remitente remitente)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(remitente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TipoDocumentoRemitenteId"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente", remitente.TipoDocumentoRemitenteId);
                ViewData["TipoEntidadId"] = new SelectList(_context.TiposContacto, "Id", "Nombre", remitente.TipoEntidadId);
                ViewData["TipoRemitenteId"] = new SelectList(_context.TiposRemitente, "Id", "Nombre", remitente.TipoRemitenteId);
                //return View(remitente);
                return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AgregarRemitente", remitente) });
            }
            */

            public JsonResult GetRemitente(string remitente)
        {

            var remitenteslist = _context.Remitentes.ToList();

            //si parametro tiene dato
            if (remitente != null)
            {
                //busco dato filtrado
                remitenteslist = _context.Remitentes.Where(x => x.NombreRemitente.Contains(remitente)).ToList();


            }

            return Json(remitenteslist);
        }


    }//public
}
