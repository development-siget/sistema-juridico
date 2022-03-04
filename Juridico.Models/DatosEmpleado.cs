using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Juridico.Models
{
    public class DatosEmpleado
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        [Required]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int? RegionalId { get; set; }
        public Regional Regional { get; set; }

        public bool Activo { get; set; }

        public List<EmpleadosRequerimiento> Requerimientos { get; set; }

    }
}
