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
    public class AnexosController : Controller
    {
        private readonly JuridicoDbContext _context;

        public AnexosController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Anexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anexos.ToListAsync());
        }

        // GET: Anexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // GET: Anexos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Anexo anexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anexo);
        }

        // GET: Anexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos.FindAsync(id);
            if (anexo == null)
            {
                return NotFound();
            }
            return View(anexo);
        }

        // POST: Anexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Anexo anexo)
        {
            if (id != anexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnexoExists(anexo.Id))
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
            return View(anexo);
        }

        // GET: Anexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // POST: Anexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anexo = await _context.Anexos.FindAsync(id);
            _context.Anexos.Remove(anexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnexoExists(int id)
        {
            return _context.Anexos.Any(e => e.Id == id);
        }
    }
}
