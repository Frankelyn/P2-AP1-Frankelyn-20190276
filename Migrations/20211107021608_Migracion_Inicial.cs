using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Frankelyn_20190276.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDeTarea",
                columns: table => new
                {
                    TipoDeTareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoAcumulado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeTarea", x => x.TipoDeTareaId);
                });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "TipoDeTareaId", "Descripcion", "TiempoAcumulado" },
                values: new object[] { 1, "Analisis", 0 });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "TipoDeTareaId", "Descripcion", "TiempoAcumulado" },
                values: new object[] { 2, "Diseño", 0 });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "TipoDeTareaId", "Descripcion", "TiempoAcumulado" },
                values: new object[] { 3, "Programacion", 0 });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "TipoDeTareaId", "Descripcion", "TiempoAcumulado" },
                values: new object[] { 4, "Prueba", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDeTarea");
        }
    }
}
