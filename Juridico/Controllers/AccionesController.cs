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
    public class AccionesController : Controller
    {
        private readonly JuridicoDbContext _context;

        public AccionesController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Acciones
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.Acciones.Include(a => a.EstadoActual).Include(a => a.EstadoSiguiente).Include(a => a.TipoAccion);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: Acciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones
                .Include(a => a.EstadoActual)
                .Include(a => a.EstadoSiguiente)
                .Include(a => a.TipoAccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accion == null)
            {
                return NotFound();
            }

            return View(accion);
        }

        // GET: Acciones/Create
        public IActionResult Create()
        {
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo");
            ViewData["EstadoSiguienteId"] = new SelectList(_context.Estados, "Id", "Codigo");
            ViewData["TipoAccionId"] = new SelectList(_context.TiposAccion, "Id", "Codigo");
            return View();
        }

        // POST: Acciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,Descripcion,EstadoActualId,EstadoSiguienteId,ValidarArchivo,TipoAccionId")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoActualId);
            ViewData["EstadoSiguienteId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoSiguienteId);
            ViewData["TipoAccionId"] = new SelectList(_context.TiposAccion, "Id", "Codigo", accion.TipoAccionId);
            return View(accion);
        }

        // GET: Acciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoActualId);
            ViewData["EstadoSiguienteId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoSiguienteId);
            ViewData["TipoAccionId"] = new SelectList(_context.TiposAccion, "Id", "Codigo", accion.TipoAccionId);
            return View(accion);
        }

        // POST: Acciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,EstadoActualId,EstadoSiguienteId,ValidarArchivo,TipoAccionId")] Accion accion)
        {
            if (id != accion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccionExists(accion.Id))
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
            ViewData["EstadoActualId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoActualId);
            ViewData["EstadoSiguienteId"] = new SelectList(_context.Estados, "Id", "Codigo", accion.EstadoSiguienteId);
            ViewData["TipoAccionId"] = new SelectList(_context.TiposAccion, "Id", "Codigo", accion.TipoAccionId);
            return View(accion);
        }

        // GET: Acciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accion = await _context.Acciones
                .Include(a => a.EstadoActual)
                .Include(a => a.EstadoSiguiente)
                .Include(a => a.TipoAccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accion == null)
            {
                return NotFound();
            }

            return View(accion);
        }

        // POST: Acciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accion = await _context.Acciones.FindAsync(id);
            _context.Acciones.Remove(accion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccionExists(int id)
        {
            return _context.Acciones.Any(e => e.Id == id);
        }
    }
}
