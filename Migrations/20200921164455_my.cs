using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintManagement.Migrations
{
    public partial class my : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impressora_Modelo_IdModelo",
                table: "Impressora");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelo",
                table: "Modelo");

            migrationBuilder.RenameTable(
                name: "Modelo",
                newName: "Modelos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Impressora_Modelos_IdModelo",
                table: "Impressora",
                column: "IdModelo",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impressora_Modelos_IdModelo",
                table: "Impressora");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos");

            migrationBuilder.RenameTable(
                name: "Modelos",
                newName: "Modelo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelo",
                table: "Modelo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Impressora_Modelo_IdModelo",
                table: "Impressora",
                column: "IdModelo",
                principalTable: "Modelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
