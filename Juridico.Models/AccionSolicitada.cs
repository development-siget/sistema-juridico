using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    //preparar respuesta, para su informacion, etc.
    public class AccionSolicitada
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Accion Solicitada")]
        public string NombreAccion { get; set; }

    }
}
