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
    public class EstadosController : Controller
    {
        private readonly JuridicoDbContext _context;

        public EstadosController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.Estados.Include(e => e.Proceso).Include(e => e.TipoEstado);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados
                .Include(e => e.Proceso)
                .Include(e => e.TipoEstado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: Estados/Create
        public IActionResult Create()
        {
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo");
            ViewData["TipoEstadoId"] = new SelectList(_context.TiposEstado, "Id", "Codigo");
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,DiasPlazo,ProcesoId,TipoEstadoId")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", estado.ProcesoId);
            ViewData["TipoEstadoId"] = new SelectList(_context.TiposEstado, "Id", "Codigo", estado.TipoEstadoId);
            return View(estado);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", estado.ProcesoId);
            ViewData["TipoEstadoId"] = new SelectList(_context.TiposEstado, "Id", "Codigo", estado.TipoEstadoId);
            return View(estado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,DiasPlazo,ProcesoId,TipoEstadoId")] Estado estado)
        {
            if (id != estado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.Id))
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
            ViewData["ProcesoId"] = new SelectList(_context.Procesos, "Id", "Codigo", estado.ProcesoId);
            ViewData["TipoEstadoId"] = new SelectList(_context.TiposEstado, "Id", "Codigo", estado.TipoEstadoId);
            return View(estado);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados
                .Include(e => e.Proceso)
                .Include(e => e.TipoEstado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }
    }
}
