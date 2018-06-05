using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Row_Invoices_invoiceNumber",
                table: "Row");

            migrationBuilder.RenameColumn(
                name: "invoiceNumber",
                table: "Row",
                newName: "invoiceNr");

            migrationBuilder.RenameIndex(
                name: "IX_Row_invoiceNumber",
                table: "Row",
                newName: "IX_Row_invoiceNr");

            migrationBuilder.RenameColumn(
                name: "invoiceNumber",
                table: "Invoices",
                newName: "invoiceNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Row_Invoices_invoiceNr",
                table: "Row",
                column: "invoiceNr",
                principalTable: "Invoices",
                principalColumn: "invoiceNr",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Row_Invoices_invoiceNr",
                table: "Row");

            migrationBuilder.RenameColumn(
                name: "invoiceNr",
                table: "Row",
                newName: "invoiceNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Row_invoiceNr",
                table: "Row",
                newName: "IX_Row_invoiceNumber");

            migrationBuilder.RenameColumn(
                name: "invoiceNr",
                table: "Invoices",
                newName: "invoiceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Row_Invoices_invoiceNumber",
                table: "Row",
                column: "invoiceNumber",
                principalTable: "Invoices",
                principalColumn: "invoiceNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
