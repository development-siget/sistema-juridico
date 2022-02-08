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
    public class TipoRemitentesController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoRemitentesController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoRemitentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposRemitente.ToListAsync());
        }

        // GET: TipoRemitentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRemitente = await _context.TiposRemitente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRemitente == null)
            {
                return NotFound();
            }

            return View(tipoRemitente);
        }

        // GET: TipoRemitentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRemitentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoRemitente tipoRemitente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRemitente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRemitente);
        }

        // GET: TipoRemitentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRemitente = await _context.TiposRemitente.FindAsync(id);
            if (tipoRemitente == null)
            {
                return NotFound();
            }
            return View(tipoRemitente);
        }

        // POST: TipoRemitentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoRemitente tipoRemitente)
        {
            if (id != tipoRemitente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRemitente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRemitenteExists(tipoRemitente.Id))
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
            return View(tipoRemitente);
        }

        // GET: TipoRemitentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRemitente = await _context.TiposRemitente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRemitente == null)
            {
                return NotFound();
            }

            return View(tipoRemitente);
        }

        // POST: TipoRemitentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRemitente = await _context.TiposRemitente.FindAsync(id);
            _context.TiposRemitente.Remove(tipoRemitente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRemitenteExists(int id)
        {
            return _context.TiposRemitente.Any(e => e.Id == id);
        }
    }
}
