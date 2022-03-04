using System;
using System.Collections.Generic;
using System.Text;

namespace Juridico.Models
{
    public class EmpleadosRequerimiento
    {
        public int DatosEmpleadosId { get; set; }
        public DatosEmpleado DatosEmpleado { get; set; }

        public int RequerimientoId { get; set; }
        public Requerimiento Requerimiento { get; set; }


    }
}
