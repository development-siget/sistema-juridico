using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juridico.Data;
using Juridico.Models;

namespace Juridico.Controllers
{
    public class EmpleadosRequerimientoController : Controller
    {
        private readonly JuridicoDbContext _context;

        public EmpleadosRequerimientoController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadosRequerimiento
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.EmpleadosRequerimiento.Include(e => e.DatosEmpleado).Include(e => e.Requerimiento);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: EmpleadosRequerimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosRequerimiento = await _context.EmpleadosRequerimiento
                .Include(e => e.DatosEmpleado)
                .Include(e => e.Requerimiento)
                .FirstOrDefaultAsync(m => m.DatosEmpleadosId == id);
            if (empleadosRequerimiento == null)
            {
                return NotFound();
            }

            return View(empleadosRequerimiento);
        }

        // GET: EmpleadosRequerimiento/Create
        public IActionResult Create()
        {


            ViewData["Usuarios"] = new SelectList(_context.DatosEmpleados.OrderBy(x=>x.Nombre), "Id", "Nombre");
            ViewData["RequerimientoId"] = new SelectList(_context.Requerimientos.OrderBy(x=>x.NombreAccion), "Id", "NombreAccion");
            return View();
        }

        // POST: EmpleadosRequerimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatosEmpleadosId,RequerimientoId")] EmpleadosRequerimiento empleadosRequerimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleadosRequerimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DatosEmpleadosId"] = new SelectList(_context.DatosEmpleados, "Id", "UserId", empleadosRequerimiento.DatosEmpleadosId);
            ViewData["RequerimientoId"] = new SelectList(_context.Requerimientos, "Id", "NombreAccion", empleadosRequerimiento.RequerimientoId);
            return View(empleadosRequerimiento);
        }

        // GET: EmpleadosRequerimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosRequerimiento = await _context.EmpleadosRequerimiento.FindAsync(id);
            if (empleadosRequerimiento == null)
            {
                return NotFound();
            }
            ViewData["DatosEmpleadosId"] = new SelectList(_context.DatosEmpleados, "Id", "UserId", empleadosRequerimiento.DatosEmpleadosId);
            ViewData["RequerimientoId"] = new SelectList(_context.Requerimientos, "Id", "NombreAccion", empleadosRequerimiento.RequerimientoId);
            return View(empleadosRequerimiento);
        }

        // POST: EmpleadosRequerimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatosEmpleadosId,RequerimientoId")] EmpleadosRequerimiento empleadosRequerimiento)
        {
            if (id != empleadosRequerimiento.DatosEmpleadosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleadosRequerimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosRequerimientoExists(empleadosRequerimiento.DatosEmpleadosId))
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
            ViewData["DatosEmpleadosId"] = new SelectList(_context.DatosEmpleados, "Id", "UserId", empleadosRequerimiento.DatosEmpleadosId);
            ViewData["RequerimientoId"] = new SelectList(_context.Requerimientos, "Id", "NombreAccion", empleadosRequerimiento.RequerimientoId);
            return View(empleadosRequerimiento);
        }

        // GET: EmpleadosRequerimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosRequerimiento = await _context.EmpleadosRequerimiento
                .Include(e => e.DatosEmpleado)
                .Include(e => e.Requerimiento)
                .FirstOrDefaultAsync(m => m.DatosEmpleadosId == id);
            if (empleadosRequerimiento == null)
            {
                return NotFound();
            }

            return View(empleadosRequerimiento);
        }

        // POST: EmpleadosRequerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleadosRequerimiento = await _context.EmpleadosRequerimiento.FindAsync(id);
            _context.EmpleadosRequerimiento.Remove(empleadosRequerimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosRequerimientoExists(int id)
        {
            return _context.EmpleadosRequerimiento.Any(e => e.DatosEmpleadosId == id);
        }
    }
}
