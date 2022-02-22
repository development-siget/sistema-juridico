using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Juridico.Data;
using Juridico.Models;

namespace Juridico.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemitentesController : ControllerBase
    {
        private readonly JuridicoDbContext _context;

        public RemitentesController(JuridicoDbContext context)
        {
            _context = context;
        }


        [HttpGet("Search")]
        public IActionResult Buscar(string term)
        {
            //var remitentes = _context.Remitentes.Where(x => x.NombreRemitente.Contains(cadena)).ToList();

            var remitenteslist = _context.Remitentes.ToList();

            //si parametro tiene dato
            if (term != null)
            {
               
                //busco dato filtrado
                remitenteslist = _context.Remitentes.Where(x => x.NombreRemitente.Contains(term)).ToList();

                

            }

            var remitentes= remitenteslist.Select(d => new
            {
                id = d.Id,
                text = $"{d.NombreRemitente}"
            });
            return Ok(remitentes);
        }


        // GET api/<RemitentesController>/5
        [HttpGet("Formulario/{id}")]
        public IActionResult GetDatosFormulario(int id)
        {
            var remitentes = _context.Remitentes
                .Select(x => new Remitente()
                {
                    Id = x.Id,
                    NombreRemitente = x.NombreRemitente,
                })
                .FirstOrDefault(x => x.Id == id);



            //.Where(x => x.Id == id);


            return Ok(remitentes);
        }


    }
}
