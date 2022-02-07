using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class TipoRemitente
    {
        //Operador redes comerciales y telecomunicaciones, transmisor, distribuidor, etc.
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Tipo Remitente")]
        public string Nombre { get; set; }

        //public ICollection<Remitente> Remitentes { get; set; }
    }
}
