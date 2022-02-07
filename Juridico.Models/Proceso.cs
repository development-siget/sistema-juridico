using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using Juridico.Models.Utilities;


namespace Juridico.Models
{
    public class Proceso
    {

        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(1)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMessageTypes.Requerido)]
        [MaxLength(140)]
        public string Descripcion { get; set; }

        public int? AccionInicialId { get; set; }

        public ICollection<Estado> Estados { get; set; }

    }
}
