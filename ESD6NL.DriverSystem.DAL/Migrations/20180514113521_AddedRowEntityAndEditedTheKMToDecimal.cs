using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class AddedRowEntityAndEditedTheKMToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalKm",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    rowId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    costs = table.Column<decimal>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    dayOfWeek = table.Column<string>(nullable: true),
                    km = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.rowId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropColumn(
                name: "totalKm",
                table: "Invoices");
        }
    }
}
