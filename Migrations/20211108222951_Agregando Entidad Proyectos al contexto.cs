using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Frankelyn_20190276.Migrations
{
    public partial class AgregandoEntidadProyectosalcontexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    ProyectoDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoDeTareaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.ProyectoDetalleId);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_TipoDeTarea_TipoDeTareaId",
                        column: x => x.TipoDeTareaId,
                        principalTable: "TipoDeTarea",
                        principalColumn: "TipoDeTareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_TipoDeTareaId",
                table: "ProyectosDetalle",
                column: "TipoDeTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
