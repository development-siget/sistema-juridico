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
    public class TipoDocumentoRemitenteController : Controller
    {
        private readonly JuridicoDbContext _context;

        public TipoDocumentoRemitenteController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: TipoDocumentoRemitente
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumentoRemitente.ToListAsync());
        }

        // GET: TipoDocumentoRemitente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentoRemitente = await _context.TipoDocumentoRemitente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumentoRemitente == null)
            {
                return NotFound();
            }

            return View(tipoDocumentoRemitente);
        }

        // GET: TipoDocumentoRemitente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoRemitente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDocumentoRemitente")] TipoDocumentoRemitente tipoDocumentoRemitente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumentoRemitente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumentoRemitente);
        }

        // GET: TipoDocumentoRemitente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentoRemitente = await _context.TipoDocumentoRemitente.FindAsync(id);
            if (tipoDocumentoRemitente == null)
            {
                return NotFound();
            }
            return View(tipoDocumentoRemitente);
        }

        // POST: TipoDocumentoRemitente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDocumentoRemitente")] TipoDocumentoRemitente tipoDocumentoRemitente)
        {
            if (id != tipoDocumentoRemitente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumentoRemitente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoRemitenteExists(tipoDocumentoRemitente.Id))
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
            return View(tipoDocumentoRemitente);
        }

        // GET: TipoDocumentoRemitente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentoRemitente = await _context.TipoDocumentoRemitente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumentoRemitente == null)
            {
                return NotFound();
            }

            return View(tipoDocumentoRemitente);
        }

        // POST: TipoDocumentoRemitente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDocumentoRemitente = await _context.TipoDocumentoRemitente.FindAsync(id);
            _context.TipoDocumentoRemitente.Remove(tipoDocumentoRemitente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoRemitenteExists(int id)
        {
            return _context.TipoDocumentoRemitente.Any(e => e.Id == id);
        }
    }
}
