using Juridico.Models;
using Microsoft.EntityFrameworkCore;

namespace Juridico.Data
{
    public class JuridicoDbContext : DbContext
    {
        public JuridicoDbContext(DbContextOptions<JuridicoDbContext> options) : base(options)
        {
            
        }

        // Mapeo de clases para la base de datos
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<AccionSolicitada> AccionesSolicitadas { get; set; }
        public DbSet<AnexoDocumento> AnexosDocumento { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentoEstado> DocumentosEstados { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<PresentadoPor> PresentadoPor { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Regional> Regionales { get; set; }
        public DbSet<Remitente> Remitentes { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<TipoAccion> TiposAccion { get; set; }
        public DbSet<TipoArchivo> TiposArchivo { get; set; }
        public DbSet<TipoContacto> TiposContacto { get; set; }
        public DbSet<TipoEstado> TiposEstado { get; set; }
        public DbSet<TipoRemitente> TiposRemitente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //
            modelBuilder.Entity<Accion>()
                .HasOne(x => x.EstadoInicial)
                .WithMany(x => x.Acciones)
                .HasForeignKey(x => x.EstadoInicialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}