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
    public class TipoArchivoController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoArchivoController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoArchivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposArchivo.ToListAsync());
        }

        // GET: TipoArchivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArchivo = await _context.TiposArchivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoArchivo == null)
            {
                return NotFound();
            }

            return View(tipoArchivo);
        }

        // GET: TipoArchivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoArchivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] TipoArchivo tipoArchivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoArchivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoArchivo);
        }

        // GET: TipoArchivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArchivo = await _context.TiposArchivo.FindAsync(id);
            if (tipoArchivo == null)
            {
                return NotFound();
            }
            return View(tipoArchivo);
        }

        // POST: TipoArchivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] TipoArchivo tipoArchivo)
        {
            if (id != tipoArchivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoArchivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoArchivoExists(tipoArchivo.Id))
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
            return View(tipoArchivo);
        }

        // GET: TipoArchivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArchivo = await _context.TiposArchivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoArchivo == null)
            {
                return NotFound();
            }

            return View(tipoArchivo);
        }

        // POST: TipoArchivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoArchivo = await _context.TiposArchivo.FindAsync(id);
            _context.TiposArchivo.Remove(tipoArchivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoArchivoExists(int id)
        {
            return _context.TiposArchivo.Any(e => e.Id == id);
        }
    }
}
