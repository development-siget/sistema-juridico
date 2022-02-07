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
        public DbSet<Requerimiento> Requerimientos { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Correspondencia> Correspondencias { get; set; }
        public DbSet<HistoricoEstados> HistoricoEstados { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Regional> Regionales { get; set; }
        public DbSet<Remitente> Remitentes { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<TipoAccion> TiposAccion { get; set; }
        public DbSet<TipoArchivo> TiposArchivo { get; set; }
        public DbSet<TipoEntidad> TiposContacto { get; set; }
        public DbSet<TipoEstado> TiposEstado { get; set; }
        public DbSet<TipoRemitente> TiposRemitente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Acciones
            modelBuilder.Entity<Accion>()
                .HasOne(x => x.EstadoActual)
                .WithMany(x => x.AccionesEstadoActual)
                .HasForeignKey(x => x.EstadoActualId)
                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Accion>()
            //    .HasOne(x => x.EstadoSiguiente)
            //    .WithMany(x => x.Acciones)
            //    .HasForeignKey(x => x.EstadoSiguienteId)
            //    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Accion>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Accion>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Requerimientos
            modelBuilder.Entity<Requerimiento>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Requerimiento>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Anexos
            modelBuilder.Entity<Anexo>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Anexo>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // AnexoCorrespondencia
            modelBuilder.Entity<AnexoCorrespondiencia>()
                .HasKey(ac => new { ac.AnexoId, ac.CorrespondenciaId });
            modelBuilder.Entity<AnexoCorrespondiencia>()
                .HasOne(ac => ac.Anexo)
                .WithMany(a => a.AnexoCorrespondiencias)
                .HasForeignKey(ac => ac.AnexoId);
            modelBuilder.Entity<AnexoCorrespondiencia>()
                .HasOne(ac => ac.Correspondencia)
                .WithMany(c => c.AnexoCorrespondiencias)
                .HasForeignKey(ac => ac.CorrespondenciaId);
            // Archivos
            modelBuilder.Entity<Archivo>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Archivo>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Correspondencias
            modelBuilder.Entity<Correspondencia>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Correspondencia>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // CorrespondenciaRequerimiento
            modelBuilder.Entity<CorrespondenciaRequerimiento>()
                .HasKey(cr => new { cr.CorrespondienciaId, cr.RequerimientoId });
            modelBuilder.Entity<CorrespondenciaRequerimiento>()
                .HasOne(cr => cr.Correspondencia)
                .WithMany(c => c.CorrespondenciaRequerimientos)
                .HasForeignKey(cr => cr.CorrespondienciaId);
            modelBuilder.Entity<CorrespondenciaRequerimiento>()
                .HasOne(cr => cr.Requerimiento)
                .WithMany(r => r.CorrespondenciaRequerimientos)
                .HasForeignKey(cr => cr.RequerimientoId);
            // HistoricoEstados
            modelBuilder.Entity<HistoricoEstados>()
                .HasOne(he => he.Correspondencia)
                .WithMany(h => h.HistoricoEstados)
                .HasForeignKey(he => he.CorrespondenciaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HistoricoEstados>()
                .HasOne(he => he.Estado)
                .WithMany(e => e.HistoricoEstados)
                .HasForeignKey(he => he.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HistoricoEstados>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<HistoricoEstados>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Estados
            modelBuilder.Entity<Estado>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Estado>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Personas
            modelBuilder.Entity<Persona>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Persona>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Procesos
            modelBuilder.Entity<Proceso>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Proceso>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Regionales
            modelBuilder.Entity<Regional>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Regional>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Remitentes
            //modelBuilder.Entity<Remitente>()
            //    .HasOne(r => r.TipoRemitente)
            //    .WithOne(tr => tr.)
            modelBuilder.Entity<Remitente>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Remitente>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // Sectores
            modelBuilder.Entity<Sector>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Sector>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // TiposAccion
            modelBuilder.Entity<TipoAccion>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TipoAccion>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // TiposArchivo
            modelBuilder.Entity<TipoArchivo>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TipoArchivo>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // TiposContacto
            modelBuilder.Entity<TipoDocumentoRemitente>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TipoDocumentoRemitente>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // TiposEstado
            modelBuilder.Entity<TipoEstado>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TipoEstado>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
            // TiposRemitente
            modelBuilder.Entity<TipoRemitente>().Property<bool>("isDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TipoRemitente>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);

        }
    }
}