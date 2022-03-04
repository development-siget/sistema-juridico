using Microsoft.EntityFrameworkCore.Migrations;

namespace Juridico.Migrations
{
    public partial class DatosEmpRequerimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpleadosRequerimiento",
                columns: table => new
                {
                    DatosEmpleadosId = table.Column<int>(nullable: false),
                    RequerimientoId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosRequerimiento", x => new { x.DatosEmpleadosId, x.RequerimientoId });
                    table.ForeignKey(
                        name: "FK_EmpleadosRequerimiento_DatosEmpleados_DatosEmpleadosId",
                        column: x => x.DatosEmpleadosId,
                        principalTable: "DatosEmpleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadosRequerimiento_Requerimientos_RequerimientoId",
                        column: x => x.RequerimientoId,
                        principalTable: "Requerimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosRequerimiento_RequerimientoId",
                table: "EmpleadosRequerimiento",
                column: "RequerimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosRequerimiento");
        }
    }
}
