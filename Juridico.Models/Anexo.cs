using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    //cd, usb, folder, etc.
    public class Anexo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Anexo")]
        public string Nombre { get; set; }

        public ICollection<AnexoCorrespondiencia> AnexoCorrespondiencias { get; set; }
    }
}
