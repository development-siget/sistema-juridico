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
        [Display(Name = "Estado inicial")]
        public int EstadoInicialId { get; set; }
        public Estado EstadoInicial { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Estado final")]
        public int EstadoFinalId { get; set; }
        public Estado EstadoFinal { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Archivo obligatorio")]
        public bool ValidarArchivo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Tipo Acción")]
        public int TipoAccionId { get; set; }
        public TipoAccion TipoAccion { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [Display(Name = "Proceso")]
        public int ProcesoId { get; set; }
        public Proceso Proceso { get; set; }

    }
}
