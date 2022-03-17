using System.Linq;
using Juridico.Data;
using Juridico.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Juridico.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly JuridicoDbContext _context;

        public PersonasController(JuridicoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList(string search)
        {
            var personas = _context.Personas
                .Select(p => new Persona()
                {
                    Id = p.Id,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    Dui = p.Dui
                })
                .ToList();
            return Ok(personas);
        }

        [HttpGet("Search/{search}")]
        public IActionResult GetListSearch(string search)
        {
            var personas = _context.Personas
                .Select(p => new Persona()
                {
                    Id = p.Id,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    Dui = p.Dui
                })
                .Where(p => p.Nombres.Contains(search) || p.Apellidos.Contains(search) || p.Dui.Contains(search))
                .ToList();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var persona = _context.Personas
                .FirstOrDefault(p => p.Id == id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

    }
}
