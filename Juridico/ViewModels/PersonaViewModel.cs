using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Juridico.Models;

namespace Juridico.ViewModels
{
    public class PersonaViewModel
    {
        public int Id { get; set; }

        
        [MaxLength(100)]
        public string Nombres { get; set; }

        
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [MaxLength(10)]
        public string Dui { get; set; }

        [MaxLength(100)]
        public string OtroDocumento { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Correspondencia> Correspondencias { get; set; }


    }
}
