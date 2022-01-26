using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    //archivos adjuntos
    public class Archivo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre Archivo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ruta Archivo")]
        public string Ruta { get; set; }

        public int TipoArchivoId { get; set; }

        public TipoArchivo TipoArchivo


    }
}
