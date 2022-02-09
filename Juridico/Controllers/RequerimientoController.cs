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
    public class RequerimientoController : Controller
    {
        private readonly JuridicoDbContext _context;

        public RequerimientoController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Requerimiento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requerimientos.ToListAsync());
        }

        // GET: Requerimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requerimiento = await _context.Requerimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requerimiento == null)
            {
                return NotFound();
            }

            return View(requerimiento);
        }

        // GET: Requerimiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requerimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreAccion")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requerimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requerimiento);
        }

        // GET: Requerimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requerimiento = await _context.Requerimientos.FindAsync(id);
            if (requerimiento == null)
            {
                return NotFound();
            }
            return View(requerimiento);
        }

        // POST: Requerimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreAccion")] Requerimiento requerimiento)
        {
            if (id != requerimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requerimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequerimientoExists(requerimiento.Id))
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
            return View(requerimiento);
        }

        // GET: Requerimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requerimiento = await _context.Requerimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requerimiento == null)
            {
                return NotFound();
            }

            return View(requerimiento);
        }

        // POST: Requerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requerimiento = await _context.Requerimientos.FindAsync(id);
            _context.Requerimientos.Remove(requerimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequerimientoExists(int id)
        {
            return _context.Requerimientos.Any(e => e.Id == id);
        }
    }
}
