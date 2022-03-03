using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Juridico.ViewModels
{
    public class AccionCorrespondenciaViewModel
    {
        [Required]
        public int AccionId { get; set; }

        [Required]
        public int CorrespondenciaId { get; set; }


        [Required]
        public string Comentario { get; set; }

        public int? DatosEmpleadoId { get; set; }

        public int? EstadoActualId { get; set; }

        public int? EstadoSiguientId { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
