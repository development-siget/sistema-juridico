using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juridico.Data;
using Juridico.Models;
using Microsoft.Graph;
using Juridico.Graph;

namespace Juridico.Controllers
{
    public class DatosEmpleadosController : Controller
    {
        private readonly JuridicoDbContext _context;
        private readonly GraphServiceClient _graphServiceClient;

        public DatosEmpleadosController(JuridicoDbContext context, GraphServiceClient graphServiceClient)
        {
            _context = context;
            _graphServiceClient = graphServiceClient;
        }

        // GET: DatosEmpleados
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.DatosEmpleados.Include(d => d.Regional).Include(d => d.Rol);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: DatosEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleados
                .Include(d => d.Regional)
                .Include(d => d.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }

            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Create
        public IActionResult Create()
        {
            CargarDatos();
            return View();
        }

        private void CargarDatos()
        {
            /*
             var usuarios = _graphServiceClient.GetUserList().Select(u => new
             {
                 u.Id,
                 Nombre = $"{u.DisplayName} - {u.Mail}"
             });
             ViewData["Usuarios"] = new SelectList(usuarios, "Id", "Nombre");
             */
            var roles = _context.Roles.ToList();
            ViewData["Roles"] = new SelectList(roles, "Id", "Nombre");
            var regionales = _context.Regionales.ToList();
            ViewData["Regionales"] = new SelectList(regionales, "Id", "Nombre");
        }

        // POST: DatosEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Nombre,Email,RolId,RegionalId,Activo")] DatosEmpleado datosEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarDatos();
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleados.FindAsync(id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }
            CargarDatos();
            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Nombre,Email,RolId,RegionalId,Activo")] DatosEmpleado datosEmpleado)
        {
            if (id != datosEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosEmpleadoExists(datosEmpleado.Id))
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
            CargarDatos();
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleados
                .Include(d => d.Regional)
                .Include(d => d.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }

            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosEmpleado = await _context.DatosEmpleados.FindAsync(id);
            _context.DatosEmpleados.Remove(datosEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosEmpleadoExists(int id)
        {
            return _context.DatosEmpleados.Any(e => e.Id == id);
        }
    }
}
