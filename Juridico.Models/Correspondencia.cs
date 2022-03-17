using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Juridico.Models
{
    //Documentos que ingresan a la institucion
    public class Correspondencia
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } // numero de pcdoc

        [MaxLength(20)]
        public string Referencia { get; set; } 

        [Required]
        [MaxLength(500)]
        public string Objeto { get; set; } //descripcion del documento

        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDocumento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFinalizacion { get; set; }

        [Display(Name = "Estado Actual")]
        public int? EstadoActualId { get; set; }
        public Estado EstadoActual { get; set; }

        public string IngresadoPorNombre { get; set; } // Id de DatosEmpleado

        public int RemitenteId { get; set; } //nombre de la empresa o persona que envia la documentacion
        public Remitente Remitente { get; set; }

        public int PersonaPresentoId { get; set; }
        public Persona PersonaPresento { get; set; }

        public int RegionalId { get; set; }
        public Regional Regional { get; set; }

        public int ProcesoId { get; set; }
        public Proceso Proceso { get; set; }

        public List<HistoricoEstados> HistoricoEstados { get; set; } // estados del documento

        public ICollection<AnexoCorrespondiencia> AnexoCorrespondiencias { get; set; }

        public ICollection<CorrespondenciaRequerimiento> CorrespondenciaRequerimientos { get; set; }


    }
}
