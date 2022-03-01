using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Juridico.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<EstadosRoles> Estados { get; set; }
    }
}
