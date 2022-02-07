using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [MaxLength(10)]
        public string Dui { get; set; }

        [MaxLength(100)]
        public string OtroDocumento { get; set; }

        [Required]
        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Correspondencia> Correspondencias { get; set; }


    }
}
