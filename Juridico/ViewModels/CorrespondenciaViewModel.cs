using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Juridico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Juridico.ViewModels
{
    public class CorrespondenciaViewModel
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

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaDocumento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaFinalizacion { get; set; }

        [Display(Name = "Estado Actual")]
        public int? EstadoActualId { get; set; }
        public Estado EstadoActual { get; set; }

        public int IngresadoPorId { get; set; } // Id de DatosEmpleado
        public string IngresadoPorNombre { get; set; } 

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

        public List<Anexo> Anexos { get; set; }

        public List<int?> Id_Anexos { get; set; }

        public List<Remitente> Remitentes { get; set; }

        public List<Persona> Personas { get; set; }
        public int AnexoId { get; set; }

        public string AnexoNombre { get; set; }

        public bool IsChecked { get; set; }


        public SelectList DestinatariosSL { get; set; }

        // Guardar datos de Graph
        public string DisplayNameDestinatario { get; set; }
        public string DestinatarioId { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public List<Requerimiento> Requerimientos { get; set; }

        public List<int?> Id_Requerimiento { get; set; }

        public string Comentarios { get; set; }
    }
}
