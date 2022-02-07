﻿// <auto-generated />
using System;
using Juridico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Juridico.Migrations
{
    [DbContext(typeof(JuridicoDbContext))]
    partial class JuridicoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Juridico.Models.Accion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(140)")
                        .HasMaxLength(140);

                    b.Property<int>("EstadoActualId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoSiguienteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TipoAccionId")
                        .HasColumnType("int");

                    b.Property<bool>("ValidarArchivo")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("EstadoActualId");

                    b.HasIndex("EstadoSiguienteId");

                    b.HasIndex("TipoAccionId");

                    b.ToTable("Acciones");
                });

            modelBuilder.Entity("Juridico.Models.Anexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Anexos");
                });

            modelBuilder.Entity("Juridico.Models.AnexoCorrespondiencia", b =>
                {
                    b.Property<int>("AnexoId")
                        .HasColumnType("int");

                    b.Property<int>("CorrespondenciaId")
                        .HasColumnType("int");

                    b.HasKey("AnexoId", "CorrespondenciaId");

                    b.HasIndex("CorrespondenciaId");

                    b.ToTable("AnexoCorrespondiencia");
                });

            modelBuilder.Entity("Juridico.Models.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HistoricoEstadosId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoArchivoId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("HistoricoEstadosId");

                    b.ToTable("Archivos");
                });

            modelBuilder.Entity("Juridico.Models.Correspondencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("EstadoActualId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDocumento")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<int>("IngresadoPorId")
                        .HasColumnType("int");

                    b.Property<string>("Objeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("PersonaPresentoId")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("RegionalId")
                        .HasColumnType("int");

                    b.Property<int>("RemitenteId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("EstadoActualId");

                    b.HasIndex("PersonaPresentoId");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("RegionalId");

                    b.HasIndex("RemitenteId");

                    b.ToTable("Correspondencias");
                });

            modelBuilder.Entity("Juridico.Models.CorrespondenciaRequerimiento", b =>
                {
                    b.Property<int>("CorrespondienciaId")
                        .HasColumnType("int");

                    b.Property<int>("RequerimientoId")
                        .HasColumnType("int");

                    b.HasKey("CorrespondienciaId", "RequerimientoId");

                    b.HasIndex("RequerimientoId");

                    b.ToTable("CorrespondenciaRequerimiento");
                });

            modelBuilder.Entity("Juridico.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("DiasPlazo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEstadoId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("TipoEstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Juridico.Models.HistoricoEstados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccionId")
                        .HasColumnType("int");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ComentarioAccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("CorrespondenciaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("date");

                    b.Property<string>("NombreUsuarioCreador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("AccionId");

                    b.HasIndex("CorrespondenciaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("HistoricoEstados");
                });

            modelBuilder.Entity("Juridico.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Dui")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OtroDocumento")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Juridico.Models.Proceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccionInicialId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(140)")
                        .HasMaxLength(140);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Procesos");
                });

            modelBuilder.Entity("Juridico.Models.Regional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Regionales");
                });

            modelBuilder.Entity("Juridico.Models.Remitente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRemitente")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TipoDocumentoRemitenteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEntidadId")
                        .HasColumnType("int");

                    b.Property<int>("TipoRemitenteId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("TipoDocumentoRemitenteId");

                    b.HasIndex("TipoEntidadId");

                    b.HasIndex("TipoRemitenteId");

                    b.ToTable("Remitentes");
                });

            modelBuilder.Entity("Juridico.Models.Requerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreAccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Requerimientos");
                });

            modelBuilder.Entity("Juridico.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("Juridico.Models.TipoAccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("TiposAccion");
                });

            modelBuilder.Entity("Juridico.Models.TipoArchivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(140)")
                        .HasMaxLength(140);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("TiposArchivo");
                });

            modelBuilder.Entity("Juridico.Models.TipoDocumentoRemitente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreDocumentoRemitente")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentoRemitente");
                });

            modelBuilder.Entity("Juridico.Models.TipoEntidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TiposContacto");
                });

            modelBuilder.Entity("Juridico.Models.TipoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("TiposEstado");
                });

            modelBuilder.Entity("Juridico.Models.TipoRemitente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("TiposRemitente");
                });

            modelBuilder.Entity("Juridico.Models.Accion", b =>
                {
                    b.HasOne("Juridico.Models.Estado", "EstadoActual")
                        .WithMany("AccionesEstadoActual")
                        .HasForeignKey("EstadoActualId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Estado", "EstadoSiguiente")
                        .WithMany()
                        .HasForeignKey("EstadoSiguienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.TipoAccion", "TipoAccion")
                        .WithMany("Acciones")
                        .HasForeignKey("TipoAccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.AnexoCorrespondiencia", b =>
                {
                    b.HasOne("Juridico.Models.Anexo", "Anexo")
                        .WithMany("AnexoCorrespondiencias")
                        .HasForeignKey("AnexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Correspondencia", "Correspondencia")
                        .WithMany("AnexoCorrespondiencias")
                        .HasForeignKey("CorrespondenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.Archivo", b =>
                {
                    b.HasOne("Juridico.Models.HistoricoEstados", "HistoricoEstados")
                        .WithMany("Archivos")
                        .HasForeignKey("HistoricoEstadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.Correspondencia", b =>
                {
                    b.HasOne("Juridico.Models.Estado", "EstadoActual")
                        .WithMany()
                        .HasForeignKey("EstadoActualId");

                    b.HasOne("Juridico.Models.Persona", "PersonaPresento")
                        .WithMany("Correspondencias")
                        .HasForeignKey("PersonaPresentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Proceso", "Proceso")
                        .WithMany()
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Regional", "Regional")
                        .WithMany()
                        .HasForeignKey("RegionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Remitente", "Remitente")
                        .WithMany()
                        .HasForeignKey("RemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.CorrespondenciaRequerimiento", b =>
                {
                    b.HasOne("Juridico.Models.Correspondencia", "Correspondencia")
                        .WithMany("CorrespondenciaRequerimientos")
                        .HasForeignKey("CorrespondienciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Requerimiento", "Requerimiento")
                        .WithMany("CorrespondenciaRequerimientos")
                        .HasForeignKey("RequerimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.Estado", b =>
                {
                    b.HasOne("Juridico.Models.Proceso", "Proceso")
                        .WithMany("Estados")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.TipoEstado", "TipoEstado")
                        .WithMany()
                        .HasForeignKey("TipoEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.HistoricoEstados", b =>
                {
                    b.HasOne("Juridico.Models.Accion", "Accion")
                        .WithMany()
                        .HasForeignKey("AccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Correspondencia", "Correspondencia")
                        .WithMany("HistoricoEstados")
                        .HasForeignKey("CorrespondenciaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Juridico.Models.Estado", "Estado")
                        .WithMany("HistoricoEstados")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Juridico.Models.Remitente", b =>
                {
                    b.HasOne("Juridico.Models.TipoDocumentoRemitente", "TipoDocumentoRemitente")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoRemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.TipoEntidad", "TipoEntidad")
                        .WithMany()
                        .HasForeignKey("TipoEntidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Juridico.Models.TipoRemitente", "TipoRemitente")
                        .WithMany()
                        .HasForeignKey("TipoRemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
