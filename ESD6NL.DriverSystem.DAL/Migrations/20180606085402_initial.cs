using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    StreetNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "RDW",
                columns: table => new
                {
                    RdwID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aantal_cilinders = table.Column<string>(nullable: true),
                    aantal_deuren = table.Column<string>(nullable: true),
                    aantal_rolstoelplaatsen = table.Column<string>(nullable: true),
                    aantal_wielen = table.Column<string>(nullable: true),
                    aantal_zitplaatsen = table.Column<string>(nullable: true),
                    afstand_hart_koppeling_tot_achterzijde_voertuig = table.Column<string>(nullable: true),
                    afstand_voorzijde_voertuig_tot_hart_koppeling = table.Column<string>(nullable: true),
                    api_gekentekende_voertuigen_assen = table.Column<string>(nullable: true),
                    api_gekentekende_voertuigen_brandstof = table.Column<string>(nullable: true),
                    api_gekentekende_voertuigen_carrosserie = table.Column<string>(nullable: true),
                    api_gekentekende_voertuigen_carrosserie_specifiek = table.Column<string>(nullable: true),
                    api_gekentekende_voertuigen_voertuigklasse = table.Column<string>(nullable: true),
                    breedte = table.Column<string>(nullable: true),
                    bruto_bpm = table.Column<string>(nullable: true),
                    catalogusprijs = table.Column<string>(nullable: true),
                    cilinderinhoud = table.Column<string>(nullable: true),
                    datum_eerste_afgifte_nederland = table.Column<string>(nullable: true),
                    datum_eerste_toelating = table.Column<string>(nullable: true),
                    datum_tenaamstelling = table.Column<string>(nullable: true),
                    eerste_kleur = table.Column<string>(nullable: true),
                    europese_voertuigcategorie = table.Column<string>(nullable: true),
                    export_indicator = table.Column<string>(nullable: true),
                    handelsbenaming = table.Column<string>(nullable: true),
                    inrichting = table.Column<string>(nullable: true),
                    kenteken = table.Column<string>(nullable: true),
                    lengte = table.Column<string>(nullable: true),
                    massa_ledig_voertuig = table.Column<string>(nullable: true),
                    massa_rijklaar = table.Column<string>(nullable: true),
                    maximum_massa_samenstelling = table.Column<string>(nullable: true),
                    maximum_massa_trekken_ongeremd = table.Column<string>(nullable: true),
                    maximum_trekken_massa_geremd = table.Column<string>(nullable: true),
                    merk = table.Column<string>(nullable: true),
                    openstaande_terugroepactie_indicator = table.Column<string>(nullable: true),
                    plaats_chassisnummer = table.Column<string>(nullable: true),
                    taxi_indicator = table.Column<string>(nullable: true),
                    technische_max_massa_voertuig = table.Column<string>(nullable: true),
                    toegestane_maximum_massa_voertuig = table.Column<string>(nullable: true),
                    tweede_kleur = table.Column<string>(nullable: true),
                    typegoedkeuringsnummer = table.Column<string>(nullable: true),
                    uitvoering = table.Column<string>(nullable: true),
                    variant = table.Column<string>(nullable: true),
                    vermogen_massarijklaar = table.Column<string>(nullable: true),
                    vervaldatum_apk = table.Column<string>(nullable: true),
                    voertuigsoort = table.Column<string>(nullable: true),
                    volgnummer_wijziging_eu_typegoedkeuring = table.Column<string>(nullable: true),
                    wacht_op_keuren = table.Column<string>(nullable: true),
                    wam_verzekerd = table.Column<string>(nullable: true),
                    wielbasis = table.Column<string>(nullable: true),
                    zuinigheidslabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RDW", x => x.RdwID);
                });

            migrationBuilder.CreateTable(
                name: "RDWFuel",
                columns: table => new
                {
                    RDWFuelID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    brandstof_omschrijving = table.Column<string>(nullable: true),
                    brandstof_volgnummer = table.Column<string>(nullable: true),
                    brandstofverbruik_buiten = table.Column<string>(nullable: true),
                    brandstofverbruik_gecombineerd = table.Column<string>(nullable: true),
                    brandstofverbruik_stad = table.Column<string>(nullable: true),
                    co2_uitstoot_gecombineerd = table.Column<string>(nullable: true),
                    emissiecode_omschrijving = table.Column<string>(nullable: true),
                    geluidsniveau_stationair = table.Column<string>(nullable: true),
                    kenteken = table.Column<string>(nullable: true),
                    milieuklasse_eg_goedkeuring_licht = table.Column<string>(nullable: true),
                    nettomaximumvermogen = table.Column<string>(nullable: true),
                    toerental_geluidsniveau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RDWFuel", x => x.RDWFuelID);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    Translated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    birthDay = table.Column<DateTime>(nullable: false),
                    citizenServiceNumber = table.Column<long>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    lastSyncTime = table.Column<DateTime>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    carTrackerID = table.Column<string>(nullable: true),
                    licensePlate = table.Column<string>(nullable: true),
                    rdwDataRdwID = table.Column<int>(nullable: true),
                    rdwFuelDataRDWFuelID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_RDW_rdwDataRdwID",
                        column: x => x.rdwDataRdwID,
                        principalTable: "RDW",
                        principalColumn: "RdwID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_RDWFuel_rdwFuelDataRDWFuelID",
                        column: x => x.rdwFuelDataRDWFuelID,
                        principalTable: "RDWFuel",
                        principalColumn: "RDWFuelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    invoiceNr = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    filePath = table.Column<string>(nullable: true),
                    paymentStatus = table.Column<int>(nullable: false),
                    period = table.Column<DateTime>(nullable: false),
                    totalAmount = table.Column<decimal>(nullable: false),
                    totalKm = table.Column<decimal>(nullable: false),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.invoiceNr);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    rowId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    costs = table.Column<decimal>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    dayOfWeek = table.Column<string>(nullable: true),
                    invoiceNr = table.Column<long>(nullable: true),
                    km = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.rowId);
                    table.ForeignKey(
                        name: "FK_Row_Invoices_invoiceNr",
                        column: x => x.invoiceNr,
                        principalTable: "Invoices",
                        principalColumn: "invoiceNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_licensePlate",
                table: "Cars",
                column: "licensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_rdwDataRdwID",
                table: "Cars",
                column: "rdwDataRdwID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_rdwFuelDataRDWFuelID",
                table: "Cars",
                column: "rdwFuelDataRDWFuelID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_userID",
                table: "Cars",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_userID",
                table: "Invoices",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Row_invoiceNr",
                table: "Row",
                column: "invoiceNr");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressID",
                table: "Users",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email_userName",
                table: "Users",
                columns: new[] { "email", "userName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "RDW");

            migrationBuilder.DropTable(
                name: "RDWFuel");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
