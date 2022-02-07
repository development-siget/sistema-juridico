using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    //preparar respuesta, para su informacion, etc.
    public class Requerimiento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Requerimiento solicitado")]
        public string NombreAccion { get; set; }

        public ICollection<CorrespondenciaRequerimiento> CorrespondenciaRequerimientos { get; set; }

    }
}
