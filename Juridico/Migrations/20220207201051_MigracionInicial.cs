using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Juridico.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Dui = table.Column<string>(maxLength: 10, nullable: true),
                    OtroDocumento = table.Column<string>(maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false),
                    AccionInicialId = table.Column<int>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regionales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regionales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requerimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAccion = table.Column<string>(maxLength: 150, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requerimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentoRemitente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDocumentoRemitente = table.Column<string>(maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentoRemitente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposArchivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposArchivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposContacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContacto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEstado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposRemitente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRemitente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    DiasPlazo = table.Column<int>(nullable: true),
                    ProcesoId = table.Column<int>(nullable: false),
                    TipoEstadoId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estados_TiposEstado_TipoEstadoId",
                        column: x => x.TipoEstadoId,
                        principalTable: "TiposEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remitentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRemitente = table.Column<string>(maxLength: 300, nullable: false),
                    NumeroDocumento = table.Column<string>(nullable: false),
                    TipoDocumentoRemitenteId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 300, nullable: true),
                    Telefono = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    TipoEntidadId = table.Column<int>(nullable: false),
                    TipoRemitenteId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remitentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remitentes_TipoDocumentoRemitente_TipoDocumentoRemitenteId",
                        column: x => x.TipoDocumentoRemitenteId,
                        principalTable: "TipoDocumentoRemitente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Remitentes_TiposContacto_TipoEntidadId",
                        column: x => x.TipoEntidadId,
                        principalTable: "TiposContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Remitentes_TiposRemitente_TipoRemitenteId",
                        column: x => x.TipoRemitenteId,
                        principalTable: "TiposRemitente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false),
                    EstadoActualId = table.Column<int>(nullable: false),
                    EstadoSiguienteId = table.Column<int>(nullable: false),
                    ValidarArchivo = table.Column<bool>(nullable: false),
                    TipoAccionId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoActualId",
                        column: x => x.EstadoActualId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoSiguienteId",
                        column: x => x.EstadoSiguienteId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acciones_TiposAccion_TipoAccionId",
                        column: x => x.TipoAccionId,
                        principalTable: "TiposAccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Correspondencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Referencia = table.Column<string>(maxLength: 20, nullable: true),
                    Objeto = table.Column<string>(maxLength: 500, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "date", nullable: true),
                    EstadoActualId = table.Column<int>(nullable: true),
                    IngresadoPorId = table.Column<int>(nullable: false),
                    RemitenteId = table.Column<int>(nullable: false),
                    PersonaPresentoId = table.Column<int>(nullable: false),
                    RegionalId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Estados_EstadoActualId",
                        column: x => x.EstadoActualId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Personas_PersonaPresentoId",
                        column: x => x.PersonaPresentoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Regionales_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "Regionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correspondencias_Remitentes_RemitenteId",
                        column: x => x.RemitenteId,
                        principalTable: "Remitentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnexoCorrespondiencia",
                columns: table => new
                {
                    AnexoId = table.Column<int>(nullable: false),
                    CorrespondenciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoCorrespondiencia", x => new { x.AnexoId, x.CorrespondenciaId });
                    table.ForeignKey(
                        name: "FK_AnexoCorrespondiencia_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnexoCorrespondiencia_Correspondencias_CorrespondenciaId",
                        column: x => x.CorrespondenciaId,
                        principalTable: "Correspondencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrespondenciaRequerimiento",
                columns: table => new
                {
                    CorrespondienciaId = table.Column<int>(nullable: false),
                    RequerimientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrespondenciaRequerimiento", x => new { x.CorrespondienciaId, x.RequerimientoId });
                    table.ForeignKey(
                        name: "FK_CorrespondenciaRequerimiento_Correspondencias_CorrespondienciaId",
                        column: x => x.CorrespondienciaId,
                        principalTable: "Correspondencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrespondenciaRequerimiento_Requerimientos_RequerimientoId",
                        column: x => x.RequerimientoId,
                        principalTable: "Requerimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEstados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrespondenciaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    AccionId = table.Column<int>(nullable: false),
                    ComentarioAccion = table.Column<string>(maxLength: 500, nullable: false),
                    NombreUsuarioCreador = table.Column<string>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstados_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoEstados_Correspondencias_CorrespondenciaId",
                        column: x => x.CorrespondenciaId,
                        principalTable: "Correspondencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoEstados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Ruta = table.Column<string>(nullable: false),
                    TipoArchivoId = table.Column<int>(nullable: false),
                    HistoricoEstadosId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos_HistoricoEstados_HistoricoEstadosId",
                        column: x => x.HistoricoEstadosId,
                        principalTable: "HistoricoEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoActualId",
                table: "Acciones",
                column: "EstadoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoSiguienteId",
                table: "Acciones",
                column: "EstadoSiguienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_TipoAccionId",
                table: "Acciones",
                column: "TipoAccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnexoCorrespondiencia_CorrespondenciaId",
                table: "AnexoCorrespondiencia",
                column: "CorrespondenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_HistoricoEstadosId",
                table: "Archivos",
                column: "HistoricoEstadosId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrespondenciaRequerimiento_RequerimientoId",
                table: "CorrespondenciaRequerimiento",
                column: "RequerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_EstadoActualId",
                table: "Correspondencias",
                column: "EstadoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_PersonaPresentoId",
                table: "Correspondencias",
                column: "PersonaPresentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_ProcesoId",
                table: "Correspondencias",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_RegionalId",
                table: "Correspondencias",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondencias_RemitenteId",
                table: "Correspondencias",
                column: "RemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ProcesoId",
                table: "Estados",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_TipoEstadoId",
                table: "Estados",
                column: "TipoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstados_AccionId",
                table: "HistoricoEstados",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstados_CorrespondenciaId",
                table: "HistoricoEstados",
                column: "CorrespondenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstados_EstadoId",
                table: "HistoricoEstados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitentes_TipoDocumentoRemitenteId",
                table: "Remitentes",
                column: "TipoDocumentoRemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitentes_TipoEntidadId",
                table: "Remitentes",
                column: "TipoEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitentes_TipoRemitenteId",
                table: "Remitentes",
                column: "TipoRemitenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexoCorrespondiencia");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "CorrespondenciaRequerimiento");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "TiposArchivo");

            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "HistoricoEstados");

            migrationBuilder.DropTable(
                name: "Requerimientos");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Correspondencias");

            migrationBuilder.DropTable(
                name: "TiposAccion");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Regionales");

            migrationBuilder.DropTable(
                name: "Remitentes");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "TiposEstado");

            migrationBuilder.DropTable(
                name: "TipoDocumentoRemitente");

            migrationBuilder.DropTable(
                name: "TiposContacto");

            migrationBuilder.DropTable(
                name: "TiposRemitente");
        }
    }
}
