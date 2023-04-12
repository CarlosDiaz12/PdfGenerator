using Microsoft.EntityFrameworkCore.Migrations;

namespace PdfGenerator.Migrations
{
    public partial class add_identification_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentificacionCliente",
                table: "Cheques",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificacionCliente",
                table: "Cheques");
        }
    }
}
