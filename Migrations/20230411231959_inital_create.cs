using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdfGenerator.Migrations
{
    public partial class inital_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCheque = table.Column<long>(nullable: false),
                    ConceptoPago = table.Column<string>(nullable: true),
                    NombreCliente = table.Column<string>(nullable: true),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    MontoLetra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cheques");
        }
    }
}
