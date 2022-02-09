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
    public class RemitentesController : Controller
    {
        private readonly JuridicoDbContext _context;

        public RemitentesController(JuridicoDbContext context)
        {
            _context = context;
        }

        // GET: Remitentes
        public async Task<IActionResult> Index()
        {
            var juridicoDbContext = _context.Remitentes.Include(r => r.TipoDocumentoRemitente).Include(r => r.TipoEntidad).Include(r => r.TipoRemitente);
            return View(await juridicoDbContext.ToListAsync());
        }

        // GET: Remitentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remitente = await _context.Remitentes
                .Include(r => r.TipoDocumentoRemitente)
                .Include(r => r.TipoEntidad)
                .Include(r => r.TipoRemitente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remitente == null)
            {
                return NotFound();
            }

            return View(remitente);
        }

        // GET: Remitentes/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumentoRemitenteId"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente");
            ViewData["TipoEntidadId"] = new SelectList(_context.TiposContacto, "Id", "Nombre");
            ViewData["TipoRemitenteId"] = new SelectList(_context.TiposRemitente, "Id", "Nombre");
            return View();
        }

        // POST: Remitentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreRemitente,NumeroDocumento,TipoDocumentoRemitenteId,Direccion,Telefono,Email,TipoEntidadId,TipoRemitenteId")] Remitente remitente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remitente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoDocumentoRemitenteId"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente", remitente.TipoDocumentoRemitenteId);
            ViewData["TipoEntidadId"] = new SelectList(_context.TiposContacto, "Id", "Codigo", remitente.TipoEntidadId);
            ViewData["TipoRemitenteId"] = new SelectList(_context.TiposRemitente, "Id", "Nombre", remitente.TipoRemitenteId);
            return View(remitente);
        }

        // GET: Remitentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remitente = await _context.Remitentes.FindAsync(id);
            if (remitente == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumentoRemitenteId"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente", remitente.TipoDocumentoRemitenteId);
            ViewData["TipoEntidadId"] = new SelectList(_context.TiposContacto, "Id", "Codigo", remitente.TipoEntidadId);
            ViewData["TipoRemitenteId"] = new SelectList(_context.TiposRemitente, "Id", "Nombre", remitente.TipoRemitenteId);
            return View(remitente);
        }

        // POST: Remitentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreRemitente,NumeroDocumento,TipoDocumentoRemitenteId,Direccion,Telefono,Email,TipoEntidadId,TipoRemitenteId")] Remitente remitente)
        {
            if (id != remitente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remitente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemitenteExists(remitente.Id))
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
            ViewData["TipoDocumentoRemitenteId"] = new SelectList(_context.TipoDocumentoRemitente, "Id", "NombreDocumentoRemitente", remitente.TipoDocumentoRemitenteId);
            ViewData["TipoEntidadId"] = new SelectList(_context.TiposContacto, "Id", "Codigo", remitente.TipoEntidadId);
            ViewData["TipoRemitenteId"] = new SelectList(_context.TiposRemitente, "Id", "Nombre", remitente.TipoRemitenteId);
            return View(remitente);
        }

        // GET: Remitentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remitente = await _context.Remitentes
                .Include(r => r.TipoDocumentoRemitente)
                .Include(r => r.TipoEntidad)
                .Include(r => r.TipoRemitente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remitente == null)
            {
                return NotFound();
            }

            return View(remitente);
        }

        // POST: Remitentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var remitente = await _context.Remitentes.FindAsync(id);
            _context.Remitentes.Remove(remitente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemitenteExists(int id)
        {
            return _context.Remitentes.Any(e => e.Id == id);
        }


        private void LoadViewData()
        {
            var tipopersona = _context.TiposContacto
                .Select(e=> new TipoEntidad
            {
                    Id = e.Id,
                    Nombre = e.Codigo +'-'+e.Nombre
            }).ToList();

        }


    }
}
