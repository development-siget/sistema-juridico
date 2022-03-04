using System.Collections.Generic;

namespace Juridico.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; } = "fa-circle";
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; } = false;
        public bool SubMenu { get; set; } = false;
        public List<SubMenuItem> SubMenuItems { get; set; }
    }
}