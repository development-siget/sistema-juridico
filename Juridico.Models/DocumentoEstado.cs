using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Juridico.Models
{
    //Estados de los documentos
    public class DocumentoEstado
    {
        public int Id { get; set; }
        public int DocumentoId { get; set; }

        public Documento Documento { get; set; }

        public int EstadoId { get; set; }
    
        public Estado Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        public DateTime? FechaFin { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comentario { get; set; }

        [Required]
        public int AccionId { get; set; }
        public Accion Accion { get; set; }

        [Required]
        public string UsuarioCreadorId { get; set; }

        //Lista de archivos adjuntos
        public List<Archivo> Archivos { get; set; }

    }
}
