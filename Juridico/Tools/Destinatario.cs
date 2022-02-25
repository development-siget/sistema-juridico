using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Juridico.Tools
{
    public class Destinatario
    {
        public string Id { get; set; }
        
        public string DisplayName { get; set; }

        [DisplayFormat(NullDisplayText = "Sin datos, verificar AzureAD")]
        public string Department { get; set; }

        [DisplayFormat(NullDisplayText = "Sin datos, verificar AzureAD")]
        public string JobTitle { get; set; }

    }
}
