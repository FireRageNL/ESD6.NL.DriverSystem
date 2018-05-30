using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class LanguagePls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "invoiceID",
                table: "Row",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Row_invoiceID",
                table: "Row",
                column: "invoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Row_Invoices_invoiceID",
                table: "Row",
                column: "invoiceID",
                principalTable: "Invoices",
                principalColumn: "invoiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Row_Invoices_invoiceID",
                table: "Row");

            migrationBuilder.DropIndex(
                name: "IX_Row_invoiceID",
                table: "Row");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "invoiceID",
                table: "Row");
        }
    }
}
