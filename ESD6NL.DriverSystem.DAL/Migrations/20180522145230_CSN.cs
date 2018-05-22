using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class CSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "validation",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "citizenServiceNumber",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "citizenServiceNumber",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "validation",
                table: "Users",
                nullable: true);
        }
    }
}
