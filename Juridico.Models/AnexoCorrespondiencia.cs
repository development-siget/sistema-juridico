namespace Juridico.Models
{
    public class AnexoCorrespondiencia
    {
        public int AnexoId { get; set; }
        public Anexo Anexo { get; set; }

        public int CorrespondenciaId { get; set; }
        public Correspondencia Correspondencia { get; set; }

    }
}