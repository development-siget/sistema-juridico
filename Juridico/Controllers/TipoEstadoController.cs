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
    public class TipoEstadoController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoEstadoController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoEstado
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposEstado.ToListAsync());
        }

        // GET: TipoEstado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TiposEstado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            return View(tipoEstado);
        }

        // GET: TipoEstado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEstado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre")] TipoEstado tipoEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEstado);
        }

        // GET: TipoEstado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TiposEstado.FindAsync(id);
            if (tipoEstado == null)
            {
                return NotFound();
            }
            return View(tipoEstado);
        }

        // POST: TipoEstado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre")] TipoEstado tipoEstado)
        {
            if (id != tipoEstado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEstadoExists(tipoEstado.Id))
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
            return View(tipoEstado);
        }

        // GET: TipoEstado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TiposEstado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            return View(tipoEstado);
        }

        // POST: TipoEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEstado = await _context.TiposEstado.FindAsync(id);
            _context.TiposEstado.Remove(tipoEstado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEstadoExists(int id)
        {
            return _context.TiposEstado.Any(e => e.Id == id);
        }
    }
}
