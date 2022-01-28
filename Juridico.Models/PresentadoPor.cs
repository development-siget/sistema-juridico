using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class PresentadoPor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [MaxLength(300)]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


    }
}
