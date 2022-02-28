using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juridico.Data;
using Juridico.Models;
using Juridico.Helpers;
//using static Juridico.Helpers.ModalHelper;
using Juridico.ViewModels;
//using System.Web.Mvc;
using AutoMapper;
using Microsoft.Graph;
using Juridico.Graph;
using Juridico.Tools;

namespace Juridico.Controllers
{
    public class CorrespondenciaController : Controller
    {
        private readonly JuridicoDbContext _context;
        private readonly IMapper _mapper;
        private readonly GraphServiceClient _graphServiceClient;

        public CorrespondenciaController(JuridicoDbContext context, IMapper mapper, GraphServiceClient graphServiceClient)
        {
            _context = context;
            _mapper = mapper;
            _graphServiceClient = graphServiceClient;

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
        //Carga detalles de Marginar
        // GET: Correspondencia/Marginar/5
        public IActionResult Marginar(int? id)
        {

            var correspondenciavm = GetCorrespondenciaViewModel(id);
           
            if (correspondenciavm  == null)
            {
                return NotFound();
            }

            /*
            var usuarios = _graphServiceClient.GetUserList().Select(u => new
            {
                id = u.Id,
                //Nombre = $"{u.DisplayName} - {u.Mail}"
                DisplayName = u.DisplayName,
                Mail =u.Mail,
            });*/

            // var listdestinatarios = GetAllUser(null, null);

           // var usuarios = _graphServiceClient.GetUserList().ToList();
           //  ViewData["Usuarios"] = new SelectList(usuarios, "Id", "Nombre");


            return View(correspondenciavm);
            
        }


        /*
        public List<Destinatario> GetAllUser(string id, string displayname)
        {
            var listdestinatarios = new List<Destinatario>();

            var usuarios = GraphHelper.ConsultaListaUsuarios().Result.ToList();

            foreach (var item in usuarios)
            {
                listdestinatarios.Add(new Destinatario()
                {
                    Id = item.Id,
                    DisplayName = item.DisplayName
                });
            }
            return listdestinatarios;

        }
        */



        public CorrespondenciaViewModel GetCorrespondenciaViewModel(int? id)
        {
            var correspondencia = _context.Correspondencias.Select(c => new Correspondencia()
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Referencia = c.Referencia,
                FechaIngreso = c.FechaIngreso,
                FechaDocumento = c.FechaDocumento,
                FechaFinalizacion = c.FechaFinalizacion,
                Objeto = c.Objeto, 
                RemitenteId = c.Remitente.Id,  
                Remitente = new Remitente()
                { 
                  Id = c.Remitente.Id,
                  NombreRemitente = c.Remitente.NombreRemitente,
                },
                PersonaPresentoId = c.PersonaPresento.Id,   
                PersonaPresento = new Persona()
                { 
                    Id = c.PersonaPresento.Id,
                    Nombres = c.PersonaPresento.Nombres,
                    Apellidos = c.PersonaPresento.Apellidos,
                },
                RegionalId = c.Regional.Id,  
                Regional = new Regional()
                { 
                    Id = c.Regional.Id,
                    Nombre = c.Regional.Nombre,  
                },
                ProcesoId = c.Proceso.Id,  
                Proceso = new Proceso()
                { 
                    Id = c.Proceso.Id,
                    Nombre = c.Proceso.Nombre,  
                },
                IngresadoPorId = c.IngresadoPorId,
                EstadoActualId = c.EstadoActualId,
                /*
                HistoricoEstados =c.HistoricoEstados.Select(he=> new HistoricoEstados()
                { 
                   Id = he.Id,
                   CorrespondenciaId = he.CorrespondenciaId,
                   //EstadoId = he.EstadoId,
                   Estado =new Estado()
                   { 
                       Nombre = he.Estado.Nombre, 
                   },
                   FechaInicio = he.FechaInicio,
                   FechaFin = he.FechaFin,
                   FechaVencimiento = he.FechaVencimiento, 
                   Activo = he.Activo,
                   //AccionId = he.AccionId,
                   Accion = new Accion()
                   { 
                    Nombre = he.Accion.Nombre,  
                   },
                   ComentarioAccion= he.ComentarioAccion,
                   NombreUsuarioCreador =he.NombreUsuarioCreador,
                }).ToList(), 
                */
            }).FirstOrDefault(m => m.Id == id);

            if (correspondencia == null)
            {
                return null;
            }
            var requerimientos = _context.Requerimientos.ToList();
            
            var correspondenciavm = _mapper.Map<CorrespondenciaViewModel>(correspondencia);
            var estadoactual = _context.Estados.AsNoTracking().First(e => e.Id == correspondenciavm.EstadoActualId);
            correspondenciavm.EstadoActual = estadoactual;
            correspondenciavm.Requerimientos = requerimientos;

            

            return correspondenciavm;
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

        //public async Task<IActionResult>IngresarCorrespondencia(int? PersonaPresentoId, int? RemitenteId)
        public IActionResult IngresarCorrespondencia(int? PersonaPresentoId, int? RemitenteId)
        {
            var correspondenciavm = new CorrespondenciaViewModel
            {
                FechaIngreso = DateTime.Now,
                //Anexos = anexosvm,
                //Remitentes = remitentesvm,
                //Personas = personas,
            };

            // var remi = await _context.Remitentes.FindAsync(RemitenteId);
            //var remi = _context.Remitentes.Find(RemitenteId);  
            //if (remi == null)
            //{
            //    return NotFound();
            //}

            if (RemitenteId != null)
            {
                correspondenciavm.RemitenteId = RemitenteId.Value;
            }


            if (PersonaPresentoId != null)
            {
                correspondenciavm.PersonaPresentoId = PersonaPresentoId.Value;
                
            }

           // GetUltimaPersona();

            CargarDatos(PersonaPresentoId,RemitenteId);
            //ViewData["Remitentes"] = new SelectList(remitentesvm, "Id", "NombreRemitente");
            //ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            return View(correspondenciavm);
        }

        private string GenerarCorrelativo()
        {
            //obtener el correlativo de inicio de alguna tabla parametros

            var anioactual = DateTime.Now.Year;
            var correlativo = _context.Correspondencias.Where(y=>y.FechaIngreso.Year == anioactual)
                .Select(x=>x.Id).Count();
                correlativo++;

            var correlativoCadenaTexto = correlativo.ToString().PadLeft(4, '0');

            return anioactual.ToString() + "-" + correlativoCadenaTexto;

        }


        private void CargarDatos(int? PersonaPresentoId, int? RemitenteId)
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
            //todos
            
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

            if (RemitenteId != null)
            {
                var remitente = _context.Remitentes.Select(x => new Remitente
                {
                    Id = x.Id,
                    NombreRemitente = x.NombreRemitente,
                })
                  .Where(r => r.Id == RemitenteId)
                  .ToList();
                ViewData["Remitentes"] = new SelectList(remitente, "Id", "Nombres");
            }
            else
            {
                var remitente = _context.Remitentes.Select(x => new Remitente
                {
                    Id = x.Id,
                    NombreRemitente = x.NombreRemitente,
                })
                   .ToList();
                ViewData["Remitentes"] = new SelectList(remitente, "Id", "Nombres");
            }
            if (RemitenteId == null)
            {
                ViewData["Remitentes"] = new SelectList(remitentesvm, "Id", "NombreRemitente");
            }
           
            //ViewData["Remitentes"] = new SelectList(remitentesvm, "Id", "NombreRemitente");
            //ViewData["Personas"] = new SelectList(personas, "Id", "Nombres");
            ViewData["Id_Anexos"] = new SelectList(anexosvm, "Id", "Nombre");
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
