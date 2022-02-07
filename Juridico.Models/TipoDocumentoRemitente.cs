using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class TipoDocumentoRemitente
    {
        //DUI, PASAPORTE, NIT
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Documento remitente")]
        public string NombreDocumentoRemitente { get; set; }
    }
}
