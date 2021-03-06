using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Juridico.Models
{
    public class Regional
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Regional")]
        public string Nombre { get; set; }

    }
}
