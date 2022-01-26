using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{

    //Tipo de Archivo Adjunto: carta, resolucion, memo , etc.
    public class TipoArchivo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre tipo archivo")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(140)]
        [Display(Name = "Descripción de tipo archivo")]
        public string Descripcion { get; set; }
    }
}
