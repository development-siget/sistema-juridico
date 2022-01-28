using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Juridico.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccionesSolicitadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAccion = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesSolicitadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnexosDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexosDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresentadoPor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(maxLength: 300, nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentadoPor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false),
                    Codigo = table.Column<string>(maxLength: 1, nullable: false),
                    AccionInicialId = table.Column<int>(nullable: true),
                    EstadoInicialId = table.Column<int>(nullable: true)
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
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regionales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
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
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false)
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
                    Codigo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
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
                    Nombre = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRemitente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remitentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRemitente = table.Column<string>(maxLength: 300, nullable: false),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(maxLength: 300, nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TipoContactoId = table.Column<int>(nullable: false),
                    TipoRemitenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remitentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remitentes_TiposContacto_TipoContactoId",
                        column: x => x.TipoContactoId,
                        principalTable: "TiposContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Remitentes_TiposContacto_TipoRemitenteId",
                        column: x => x.TipoRemitenteId,
                        principalTable: "TiposContacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    DiasPlazo = table.Column<int>(nullable: true),
                    ProcesoId = table.Column<int>(nullable: false),
                    TipoEstadoId = table.Column<int>(nullable: false)
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
                name: "Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 140, nullable: false),
                    EstadoInicialId = table.Column<int>(nullable: false),
                    EstadoFinalId = table.Column<int>(nullable: false),
                    ValidarArchivo = table.Column<bool>(nullable: false),
                    TipoAccionId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoFinalId",
                        column: x => x.EstadoFinalId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoInicialId",
                        column: x => x.EstadoInicialId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acciones_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
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
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correlativo = table.Column<string>(maxLength: 20, nullable: false),
                    Referencia = table.Column<string>(nullable: true),
                    Objeto = table.Column<string>(nullable: true),
                    Anexos = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "date", nullable: true),
                    EstadoActualId = table.Column<int>(nullable: true),
                    IngresadoPorId = table.Column<int>(nullable: false),
                    TipoRemitenteId = table.Column<int>(nullable: false),
                    RemitenteId = table.Column<int>(nullable: false),
                    RegionalId = table.Column<int>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Estados_EstadoActualId",
                        column: x => x.EstadoActualId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentos_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_Regionales_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "Regionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_Remitentes_RemitenteId",
                        column: x => x.RemitenteId,
                        principalTable: "Remitentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_TiposRemitente_TipoRemitenteId",
                        column: x => x.TipoRemitenteId,
                        principalTable: "TiposRemitente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosEstados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentoId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: false),
                    AccionId = table.Column<int>(nullable: false),
                    UsuarioCreadorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosEstados_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentosEstados_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentosEstados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DocumentoEstadoId = table.Column<int>(nullable: true),
                    DocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos_DocumentosEstados_DocumentoEstadoId",
                        column: x => x.DocumentoEstadoId,
                        principalTable: "DocumentosEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Archivos_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoFinalId",
                table: "Acciones",
                column: "EstadoFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoInicialId",
                table: "Acciones",
                column: "EstadoInicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_ProcesoId",
                table: "Acciones",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_TipoAccionId",
                table: "Acciones",
                column: "TipoAccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_DocumentoEstadoId",
                table: "Archivos",
                column: "DocumentoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_DocumentoId",
                table: "Archivos",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_EstadoActualId",
                table: "Documentos",
                column: "EstadoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProcesoId",
                table: "Documentos",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_RegionalId",
                table: "Documentos",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_RemitenteId",
                table: "Documentos",
                column: "RemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoRemitenteId",
                table: "Documentos",
                column: "TipoRemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosEstados_AccionId",
                table: "DocumentosEstados",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosEstados_DocumentoId",
                table: "DocumentosEstados",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosEstados_EstadoId",
                table: "DocumentosEstados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ProcesoId",
                table: "Estados",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_TipoEstadoId",
                table: "Estados",
                column: "TipoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitentes_TipoContactoId",
                table: "Remitentes",
                column: "TipoContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitentes_TipoRemitenteId",
                table: "Remitentes",
                column: "TipoRemitenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionesSolicitadas");

            migrationBuilder.DropTable(
                name: "AnexosDocumento");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "PresentadoPor");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "TiposArchivo");

            migrationBuilder.DropTable(
                name: "DocumentosEstados");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "TiposAccion");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Regionales");

            migrationBuilder.DropTable(
                name: "Remitentes");

            migrationBuilder.DropTable(
                name: "TiposRemitente");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "TiposEstado");

            migrationBuilder.DropTable(
                name: "TiposContacto");
        }
    }
}
