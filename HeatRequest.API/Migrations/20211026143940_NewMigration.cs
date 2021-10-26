using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeatRequest.API.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Heat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sicaklik = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    MakinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Heat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Heat");
        }
    }
}
