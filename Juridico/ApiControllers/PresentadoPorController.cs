using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Juridico.Data;
using Juridico.Models;
using Juridico.ViewModels;
using AutoMapper;

namespace Juridico.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentadoPorController : ControllerBase
    {
        private readonly JuridicoDbContext _context;
        private readonly IMapper _mapper;

        public PresentadoPorController(JuridicoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Search")]
        public IActionResult Buscar(string term)
        {

            var personas = _context.Personas
              .Where(d => d.Dui.Contains(term) ||
                          d.Nombres.Contains(term) ||
                          d.Apellidos.Contains(term) ||
                          d.OtroDocumento.Contains(term))
                          
              .ToList();
            var datospersonaFiltrado = personas
                .Select(d => new
                {
                    id = d.Id,
                    text = $"{d.Dui} - {d.Nombres} {d.Apellidos}"
                });
            return Ok(datospersonaFiltrado);


        }

        // GET api/<DatosClienteController>/5
        [HttpGet("Formulario/{id}")]
        public IActionResult GetDatosFormulario(int id)
        {
            var datosPersonas = _context.Personas
                .Select(x => new Persona()
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Dui = x.Dui,
                    OtroDocumento = x.OtroDocumento,
                   
                })
                .FirstOrDefault(x => x.Id == id);
            return Ok(datosPersonas);
        }

        // POST api/<PresentadoPorController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonaViewModel personaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var datosPersona = _mapper.Map<Persona>(personaViewModel);

           
            _context.Personas.Add(datosPersona);
            _context.SaveChanges();

            return CreatedAtAction("GetDatosPersona", new { id = datosPersona.Id }, datosPersona);
        }

        [HttpGet("{id}")]
        public IActionResult GetDatosPersona(int id)
        {
            var datosPersona = _context.Personas
                 .Select(x => new Persona()
                 {
                     Id = x.Id ,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Dui = x.Dui,
                     OtroDocumento = x.OtroDocumento,
                     Direccion = x.Direccion,
                     Email = x.Email,
                     Telefono = x.Telefono, 

                 }).FirstOrDefault(x => x.Id == id);
            if (datosPersona == null)
            {
                return NotFound();
            }
            return Ok(datosPersona);
        }


        // GET: api/<PresentadoPorController>
        [HttpGet]
        public IActionResult GetDatosPersona()
        {
            var datosPersona = _context.Personas
                    .Select(x => new Persona()
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        Apellidos = x.Apellidos,
                        Dui = x.Dui,
                        OtroDocumento = x.OtroDocumento,
                        Direccion = x.Direccion,
                        Email = x.Email,
                        Telefono = x.Telefono,

                    })
                .ToList();
          
            return Ok(datosPersona);
        }




    }
}
