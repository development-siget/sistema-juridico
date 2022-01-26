using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Juridico.Models
{
    public class TipoAccion
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public List<Accion> Acciones { get; set; }
    }
}
