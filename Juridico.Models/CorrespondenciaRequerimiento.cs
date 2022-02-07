namespace Juridico.Models
{
    public class CorrespondenciaRequerimiento
    {
        public int CorrespondienciaId { get; set; }
        public Correspondencia Correspondencia { get; set; }

        public int RequerimientoId { get; set; }
        public Requerimiento Requerimiento { get; set; }
    }
}