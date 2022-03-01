using Microsoft.EntityFrameworkCore.Migrations;

namespace Juridico.Migrations
{
    public partial class DatosEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "Codigo",
                table: "TiposRemitente");*/

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    RegionalId = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosEmpleados_Regionales_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "Regionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DatosEmpleados_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadosRoles",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosRoles", x => new { x.EstadoId, x.RolId });
                    table.ForeignKey(
                        name: "FK_EstadosRoles_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadosRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosEmpleados_RegionalId",
                table: "DatosEmpleados",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_DatosEmpleados_RolId",
                table: "DatosEmpleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosRoles_RolId",
                table: "EstadosRoles",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosEmpleados");

            migrationBuilder.DropTable(
                name: "EstadosRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "TiposRemitente",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
