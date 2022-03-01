using System;
using System.Collections.Generic;
using System.Text;

namespace Juridico.Models
{
    public class EstadosRoles
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
