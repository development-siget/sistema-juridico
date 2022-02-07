using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Juridico.Models.Utilities;



namespace Juridico.Models
{
    [Table("Acciones")]
    public class Accion
    {

        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(140)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Estado actual")]
        public int EstadoActualId { get; set; }
        public Estado EstadoActual { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Estado siguiente")]
        public int EstadoSiguienteId { get; set; }
        public Estado EstadoSiguiente { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Archivo obligatorio")]
        public bool ValidarArchivo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Tipo Acción")]
        public int TipoAccionId { get; set; }
        public TipoAccion TipoAccion { get; set; }

    }
}
