using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class TipoDocumentoContacto
    {
        //DUI, PASAPORTE, NIT
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Documento Contacto")]
        public string NombreDocumentoContacto { get; set; }
    }
}
