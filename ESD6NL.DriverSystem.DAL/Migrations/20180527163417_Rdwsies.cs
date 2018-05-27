using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    public partial class Rdwsies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "brandstof_omschrijving",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandstof_volgnummer",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandstofverbruik_buiten",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandstofverbruik_gecombineerd",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandstofverbruik_stad",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "co2_uitstoot_gecombineerd",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emissiecode_omschrijving",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "geluidsniveau_stationair",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kenteken",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "milieuklasse_eg_goedkeuring_licht",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nettomaximumvermogen",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "toerental_geluidsniveau",
                table: "RDWFuel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aantal_cilinders",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aantal_deuren",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aantal_rolstoelplaatsen",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aantal_wielen",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aantal_zitplaatsen",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "afstand_hart_koppeling_tot_achterzijde_voertuig",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "afstand_voorzijde_voertuig_tot_hart_koppeling",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "api_gekentekende_voertuigen_assen",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "api_gekentekende_voertuigen_brandstof",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "api_gekentekende_voertuigen_carrosserie",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "api_gekentekende_voertuigen_carrosserie_specifiek",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "api_gekentekende_voertuigen_voertuigklasse",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "breedte",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bruto_bpm",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "catalogusprijs",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cilinderinhoud",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "datum_eerste_afgifte_nederland",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "datum_eerste_toelating",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "datum_tenaamstelling",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eerste_kleur",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "europese_voertuigcategorie",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "export_indicator",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "handelsbenaming",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inrichting",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kenteken",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lengte",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "massa_ledig_voertuig",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "massa_rijklaar",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maximum_massa_samenstelling",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maximum_massa_trekken_ongeremd",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "maximum_trekken_massa_geremd",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "merk",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "openstaande_terugroepactie_indicator",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "plaats_chassisnummer",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxi_indicator",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "technische_max_massa_voertuig",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "toegestane_maximum_massa_voertuig",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tweede_kleur",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typegoedkeuringsnummer",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uitvoering",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "variant",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vermogen_massarijklaar",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vervaldatum_apk",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "voertuigsoort",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "volgnummer_wijziging_eu_typegoedkeuring",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wacht_op_keuren",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wam_verzekerd",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wielbasis",
                table: "RDW",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zuinigheidslabel",
                table: "RDW",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brandstof_omschrijving",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "brandstof_volgnummer",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "brandstofverbruik_buiten",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "brandstofverbruik_gecombineerd",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "brandstofverbruik_stad",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "co2_uitstoot_gecombineerd",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "emissiecode_omschrijving",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "geluidsniveau_stationair",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "kenteken",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "milieuklasse_eg_goedkeuring_licht",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "nettomaximumvermogen",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "toerental_geluidsniveau",
                table: "RDWFuel");

            migrationBuilder.DropColumn(
                name: "aantal_cilinders",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "aantal_deuren",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "aantal_rolstoelplaatsen",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "aantal_wielen",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "aantal_zitplaatsen",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "afstand_hart_koppeling_tot_achterzijde_voertuig",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "afstand_voorzijde_voertuig_tot_hart_koppeling",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "api_gekentekende_voertuigen_assen",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "api_gekentekende_voertuigen_brandstof",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "api_gekentekende_voertuigen_carrosserie",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "api_gekentekende_voertuigen_carrosserie_specifiek",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "api_gekentekende_voertuigen_voertuigklasse",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "breedte",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "bruto_bpm",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "catalogusprijs",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "cilinderinhoud",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "datum_eerste_afgifte_nederland",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "datum_eerste_toelating",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "datum_tenaamstelling",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "eerste_kleur",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "europese_voertuigcategorie",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "export_indicator",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "handelsbenaming",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "inrichting",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "kenteken",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "lengte",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "massa_ledig_voertuig",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "massa_rijklaar",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "maximum_massa_samenstelling",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "maximum_massa_trekken_ongeremd",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "maximum_trekken_massa_geremd",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "merk",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "openstaande_terugroepactie_indicator",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "plaats_chassisnummer",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "taxi_indicator",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "technische_max_massa_voertuig",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "toegestane_maximum_massa_voertuig",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "tweede_kleur",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "typegoedkeuringsnummer",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "uitvoering",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "variant",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "vermogen_massarijklaar",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "vervaldatum_apk",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "voertuigsoort",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "volgnummer_wijziging_eu_typegoedkeuring",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "wacht_op_keuren",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "wam_verzekerd",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "wielbasis",
                table: "RDW");

            migrationBuilder.DropColumn(
                name: "zuinigheidslabel",
                table: "RDW");
        }
    }
}
