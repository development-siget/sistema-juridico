using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Juridico.Models
{
    [Table("Sectores")]
    public class Sector
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
