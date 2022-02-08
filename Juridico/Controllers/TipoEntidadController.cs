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
    public class TipoEntidadController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoEntidadController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoEntidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposContacto.ToListAsync());
        }

        // GET: TipoEntidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEntidad = await _context.TiposContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEntidad == null)
            {
                return NotFound();
            }

            return View(tipoEntidad);
        }

        // GET: TipoEntidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEntidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre")] TipoEntidad tipoEntidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEntidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEntidad);
        }

        // GET: TipoEntidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEntidad = await _context.TiposContacto.FindAsync(id);
            if (tipoEntidad == null)
            {
                return NotFound();
            }
            return View(tipoEntidad);
        }

        // POST: TipoEntidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre")] TipoEntidad tipoEntidad)
        {
            if (id != tipoEntidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEntidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEntidadExists(tipoEntidad.Id))
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
            return View(tipoEntidad);
        }

        // GET: TipoEntidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEntidad = await _context.TiposContacto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEntidad == null)
            {
                return NotFound();
            }

            return View(tipoEntidad);
        }

        // POST: TipoEntidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEntidad = await _context.TiposContacto.FindAsync(id);
            _context.TiposContacto.Remove(tipoEntidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEntidadExists(int id)
        {
            return _context.TiposContacto.Any(e => e.Id == id);
        }
    }
}
