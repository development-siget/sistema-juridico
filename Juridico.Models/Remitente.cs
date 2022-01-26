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
        public string NumeroDocumento { get; set; }

        [MaxLength(300)]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        //public int TipoDocumentoContactoId { get; set; }
        //public TipoDocumentoContacto TipoDocumentoContacto{ get; set; }

        public int TipoRemitenteId { get; set; }
        public TipoContacto TipoRemitente { get; set; }
    }
}
