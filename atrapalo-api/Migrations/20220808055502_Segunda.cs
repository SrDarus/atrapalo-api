using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atrapalo_api.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Modelo_ModeloId",
                table: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_ModeloId",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "Vehiculo");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Vehiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Vehiculo");

            migrationBuilder.AddColumn<long>(
                name: "ModeloId",
                table: "Vehiculo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ModeloId",
                table: "Vehiculo",
                column: "ModeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Modelo_ModeloId",
                table: "Vehiculo",
                column: "ModeloId",
                principalTable: "Modelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
