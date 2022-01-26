using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Juridico.Models
{
    //Documentos que ingresan a la institucion
    public class Documento
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Correlativo { get; set; } // numero de pcdoc

        public string Referencia { get; set; } 

        public string Objeto { get; set; } //descripcion del documento

        public string Anexos { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDocumento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFinalizacion { get; set; }

        [Display(Name = "Estado Actual")]
        public int? EstadoActualId { get; set; }
        public Estado EstadoActual { get; set; }

        public int IngresadoPorId { get; set; } // Id de DatosEmpleado

        public int TipoRemitenteId { get; set; } // generador, comercializador, etc.

        public TipoRemitente TipoRemitente { get; set; }

        public int RemitenteId { get; set; } //nombre de la empresa o persona que envia la documentacion

        public Remitente Remitente { get; set; }

        public int RegionalId { get; set; }

        public Regional Regional { get; set; }

        public int ProcesoId { get; set; }
        public Proceso Proceso { get; set; }

        public List<DocumentoEstado> DocumentoEstados { get; set; } // estados del documento

        public List<Archivo> Archivos { get; set; } //adjuntos
    }
}
