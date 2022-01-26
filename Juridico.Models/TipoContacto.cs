using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class TipoContacto
    {
        // persona natural o juridica
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tipo Persona")]
        public string Nombre { get; set; }
    }
}
