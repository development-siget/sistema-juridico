using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Juridico.Models.Utilities;

namespace Juridico.Models
{
    public class Estado
    {

        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(5)]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [DisplayName("Días Plazo")]
        [DisplayFormat(NullDisplayText = "Sin plazo")]
        public int? DiasPlazo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [DisplayName("Proceso")]
        public int ProcesoId { get; set; }
        [JsonIgnore]
        public Proceso Proceso { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        public int TipoEstadoId { get; set; }
        public TipoEstado TipoEstado { get; set; }

        // Relaciones
        [JsonIgnore]
        public ICollection<Accion> Acciones { get; set; }


    }
}

