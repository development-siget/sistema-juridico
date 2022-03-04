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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Juridico.Extensions;
using Juridico.Utilities; 

namespace Juridico.Controllers
{
    public class CorrespondenciaController : Controller
    {
        private readonly JuridicoDbContext _context;
        private readonly IMapper _mapper;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ClaimsPrincipal _user;

        public CorrespondenciaController(JuridicoDbContext context, IMapper mapper, GraphServiceClient graphServiceClient, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _graphServiceClient = graphServiceClient;
            _user = httpContextAccessor.HttpContext.User;

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


        // GET: Correspondencia/IngresarCorrespondencia

        //public async Task<IActionResult>IngresarCorrespondencia(int? PersonaPresentoId, int? RemitenteId)
        public IActionResult IngresarCorrespondencia(int? PersonaPresentoId, int? RemitenteId)
        {
            var correspondenciavm = new CorrespondenciaViewModel
            {
                FechaIngreso = DateTime.Now,
                FechaDocumento = DateTime.Now,
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
            correspondenciavm.Codigo = GenerarCorrelativoInicial();

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


        private string GenerarCorrelativoInicial()
        {
            var anioactual = DateTime.Now.Year;
            return anioactual + "-#####";

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
     
        // POST: Correspondencia/IngresarCorrespondencia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IngresarCorrespondencia(CorrespondenciaViewModel correspondenciavm)
        {
           

            var proceso = _context.Procesos.AsNoTracking().First(p => p.Codigo == "M"); //flujo de marginacion

            correspondenciavm.Codigo = GenerarCorrelativo();

           // if (ModelState.IsValid)
           // {

                //correspondenciavm.Codigo = GenerarCorrelativo();
                correspondenciavm.FechaIngreso = DateTime.Now;

                // Asignar quien recibira la correspondencia

                // Si el usuario está logueado guardar el id de empleado
                if (_user.Identity.IsAuthenticated)
                {
                   // var empleadoId = _context.DatosEmpleados.FirstOrDefault(de => de.UserId.Equals(_user.GetUserGraphId()))?.Id;
                   // correspondenciavm.IngresadoPorId = empleadoId;
                }
                else
                {
                    correspondenciavm.IngresadoPorId = 0;
                }

            // Envío de email 

            // Envío de email a persona que marginara la correspondencia

            var correspond = new Correspondencia
            {
                Codigo = correspondenciavm.Codigo,
                Referencia = correspondenciavm.Referencia,
                Objeto= correspondenciavm.Objeto,
                FechaIngreso = correspondenciavm.FechaIngreso,
                FechaDocumento = correspondenciavm.FechaDocumento,
                RemitenteId = correspondenciavm.RemitenteId,
                PersonaPresentoId = correspondenciavm.PersonaPresentoId,
                RegionalId = 1,
                ProcesoId = proceso.Id,
                EstadoActualId =1,
                IngresadoPorId = 1,

            };
                   //_mapper.Map<Correspondencia>(correspondenciavm);
                _context.Add(correspond);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al guardar el caso en la base de datos");
                }

            var accionInicial = _context.Acciones.FirstOrDefault(x => x.Id == proceso.AccionInicialId);

                if (accionInicial != null)
                {
                    var accionCorrespondenciaInicial = new AccionCorrespondenciaViewModel()
                    {
                        AccionId = accionInicial.Id,
                        CorrespondenciaId= correspond.Id,
                        Comentario = "El correspondencia fue ingresada correctamente",
                        EstadoActualId = accionInicial.EstadoActualId,
                        EstadoSiguientId = accionInicial.EstadoSiguienteId,
                        
                    };
                    //intertar estado
                    InsertarEstado(accionCorrespondenciaInicial);

                }
                else
                {
                    throw new Exception($"Error, no esta configurado la acción inicial del proceso");
                }

                //Enviar aqui el mail para la persona a quien se marginara (asignacion)


                // Mensaje de éxito de caso ingresado
         //
         //TempData.AlertSuccessMessage(CommonMessages.DatosGuardadosExitosamente);
           //     return RedirectToAction(nameof(Index));
           //} //isvalid
          
            CargarDatos(null, null);
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

                _context.Personas.Add(datosPersona);
                _context.SaveChanges();

                correspondenciavm.PersonaPresentoId = datosPersona.Id;
                return RedirectToAction(nameof(IngresarCorrespondencia), new { id = datosPersona.Id });
          
        }


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

           public bool InsertarEstado(AccionCorrespondenciaViewModel accionCorrespondenciavm)
           {
            var accion = _context.Acciones
                  .FirstOrDefault(x => x.Id == accionCorrespondenciavm.AccionId);

            var correspondencia = _context.Correspondencias
                  .FirstOrDefault(c => c.Id == accionCorrespondenciavm.CorrespondenciaId);

            var estadonuevo = _context.Estados.FirstOrDefault(x => x.Id == accion.EstadoSiguienteId); //deberia de ser estado =2
            var correspondenciaEstadoAnterior = _context.HistoricoEstados
                .FirstOrDefault(h => h.CorrespondenciaId == correspondencia.Id && h.Activo);
            if (correspondenciaEstadoAnterior != null)
            {
                correspondenciaEstadoAnterior.Activo = false;
                correspondenciaEstadoAnterior.FechaFin = DateTime.Now;
                _context.SaveChanges();  
            }

            var correspondenciaEstadoActual = new HistoricoEstados()
            {
                CorrespondenciaId = correspondencia.Id,
                EstadoId = estadonuevo.Id,
                FechaInicio = DateTime.Now,
                FechaFin =null,
                FechaVencimiento =null,
                Activo =true,
                AccionId = accionCorrespondenciavm.AccionId,  
                ComentarioAccion = accionCorrespondenciavm.Comentario,
                NombreUsuarioCreador ="prueba", //sacar usuario del displayname del graph
            };

            correspondencia.EstadoActualId = correspondenciaEstadoActual.EstadoId;
            _context.HistoricoEstados.Add(correspondenciaEstadoActual);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Error, no se guardó correctamente el nuevo estado");
            }

            return true;

        }
            
    }//public
}
