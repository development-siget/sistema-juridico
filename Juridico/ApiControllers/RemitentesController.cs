using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Juridico.Data;
using Juridico.Models;
using Microsoft.AspNetCore.Authorization;

namespace Juridico.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RemitentesController : ControllerBase
    {
        private readonly JuridicoDbContext _context;

        public RemitentesController(JuridicoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList(string search)
        {
            var remitentes = _context.Remitentes
                .Select(r => new Remitente()
                {
                    Id = r.Id,
                    NombreRemitente = r.NombreRemitente
                })
                .ToList();
            return Ok(remitentes);
        }

        [HttpGet("Search/{search}")]
        public IActionResult GetListSearch(string search)
        {
            var remitentes = _context.Remitentes
                .Select(r => new Remitente()
                {
                    Id = r.Id,
                    NombreRemitente = r.NombreRemitente
                })
                .Where(r => search == null || r.NombreRemitente.Contains(search))
                .ToList();
            return Ok(remitentes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var remitente = _context.Remitentes
                .FirstOrDefault(r => r.Id == id);
            if (remitente == null) return NotFound();
            return Ok(remitente);
        }

    }
}
