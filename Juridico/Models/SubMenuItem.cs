namespace Juridico.Models
{
    public class SubMenuItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string Nombre { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; } = false;
    }
}