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
    public class TipoAccionController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoAccionController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoAccion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposAccion.ToListAsync());
        }

        // GET: TipoAccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccion = await _context.TiposAccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAccion == null)
            {
                return NotFound();
            }

            return View(tipoAccion);
        }

        // GET: TipoAccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre")] TipoAccion tipoAccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAccion);
        }

        // GET: TipoAccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccion = await _context.TiposAccion.FindAsync(id);
            if (tipoAccion == null)
            {
                return NotFound();
            }
            return View(tipoAccion);
        }

        // POST: TipoAccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre")] TipoAccion tipoAccion)
        {
            if (id != tipoAccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAccionExists(tipoAccion.Id))
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
            return View(tipoAccion);
        }

        // GET: TipoAccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccion = await _context.TiposAccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAccion == null)
            {
                return NotFound();
            }

            return View(tipoAccion);
        }

        // POST: TipoAccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAccion = await _context.TiposAccion.FindAsync(id);
            _context.TiposAccion.Remove(tipoAccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAccionExists(int id)
        {
            return _context.TiposAccion.Any(e => e.Id == id);
        }
    }
}
