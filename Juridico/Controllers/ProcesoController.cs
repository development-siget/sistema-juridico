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
    public class ProcesoController : Controller
    {
        private readonly JuridicoDbContext _context;

        public ProcesoController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Proceso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procesos.ToListAsync());
        }

        // GET: Proceso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Procesos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // GET: Proceso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proceso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,Descripcion,AccionInicialId")] Proceso proceso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proceso);
        }

        // GET: Proceso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Procesos.FindAsync(id);
            if (proceso == null)
            {
                return NotFound();
            }
            return View(proceso);
        }

        // POST: Proceso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,AccionInicialId")] Proceso proceso)
        {
            if (id != proceso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesoExists(proceso.Id))
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
            return View(proceso);
        }

        // GET: Proceso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceso = await _context.Procesos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proceso == null)
            {
                return NotFound();
            }

            return View(proceso);
        }

        // POST: Proceso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proceso = await _context.Procesos.FindAsync(id);
            _context.Procesos.Remove(proceso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesoExists(int id)
        {
            return _context.Procesos.Any(e => e.Id == id);
        }
    }
}
