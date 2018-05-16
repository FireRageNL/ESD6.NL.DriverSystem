using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class SmallChangeInCarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "licencePlate",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "licencePlate",
                table: "Cars",
                nullable: true);
        }
    }
}
