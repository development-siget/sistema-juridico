using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Juridico.Models;

namespace Juridico.Data
{
    public class JURIDICODBContext : DbContext
    {
        public JURIDICODBContext(DbContextOptions<JURIDICODBContext> options) : base(options)
        { 
        
        }

        // Mapeo de clases para la base de datos





    }
}
