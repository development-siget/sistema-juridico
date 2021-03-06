using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    // persona natural o juridica que envia documentos a la institucion
    public class Remitente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Nombre Remitente")]
        public string NombreRemitente { get; set; }

        [Required]
        public string NumeroDocumento { get; set; }

        public int TipoDocumentoRemitenteId { get; set; }
        public TipoDocumentoRemitente TipoDocumentoRemitente { get; set; }

        [MaxLength(300)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        public int TipoEntidadId { get; set; } // natural o juridico
        public TipoEntidad TipoEntidad { get; set; }

        public int TipoRemitenteId { get; set; } // generador , distribuidor etc.
        public TipoRemitente TipoRemitente { get; set; }
    }
}
