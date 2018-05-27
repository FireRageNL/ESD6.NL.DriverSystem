﻿// <auto-generated />
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ESD6NL.DriverSystem.DAL.Migrations
{
    [DbContext(typeof(DriverSystemContext))]
    partial class DriverSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<int>("StreetNr");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("carTrackerID");

                    b.Property<string>("licensePlate");

                    b.Property<int?>("rdwDataRdwID");

                    b.Property<int?>("rdwFuelDataRDWFuelID");

                    b.Property<int?>("userID");

                    b.HasKey("CarID");

                    b.HasIndex("rdwDataRdwID");

                    b.HasIndex("rdwFuelDataRDWFuelID");

                    b.HasIndex("userID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Invoice", b =>
                {
                    b.Property<int>("invoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("filePath");

                    b.Property<long>("invoiceNumber");

                    b.Property<int>("paymentStatus");

                    b.Property<DateTime>("period");

                    b.Property<decimal>("totalAmount");

                    b.Property<decimal>("totalKm");

                    b.Property<int?>("userID");

                    b.HasKey("invoiceID");

                    b.HasIndex("userID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.RDW", b =>
                {
                    b.Property<int>("RdwID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("RdwID");

                    b.ToTable("RDW");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.RDWFuel", b =>
                {
                    b.Property<int>("RDWFuelID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("RDWFuelID");

                    b.ToTable("RDWFuel");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Row", b =>
                {
                    b.Property<int>("rowId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("costs");

                    b.Property<DateTime>("date");

                    b.Property<string>("dayOfWeek");

                    b.Property<decimal>("km");

                    b.HasKey("rowId");

                    b.ToTable("Row");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Translation", b =>
                {
                    b.Property<int>("TranslationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language");

                    b.Property<string>("Term");

                    b.Property<string>("Translated");

                    b.HasKey("TranslationID");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressID");

                    b.Property<DateTime>("birthDay");

                    b.Property<long>("citizenServiceNumber");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("userName");

                    b.HasKey("userID");

                    b.HasIndex("AddressID");

                    b.HasIndex("email", "userName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Car", b =>
                {
                    b.HasOne("ESD6NL.DriverSystem.Entities.RDW", "rdwData")
                        .WithMany()
                        .HasForeignKey("rdwDataRdwID");

                    b.HasOne("ESD6NL.DriverSystem.Entities.RDWFuel", "rdwFuelData")
                        .WithMany()
                        .HasForeignKey("rdwFuelDataRDWFuelID");

                    b.HasOne("ESD6NL.DriverSystem.Entities.User")
                        .WithMany("cars")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.Invoice", b =>
                {
                    b.HasOne("ESD6NL.DriverSystem.Entities.User")
                        .WithMany("invoices")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("ESD6NL.DriverSystem.Entities.User", b =>
                {
                    b.HasOne("ESD6NL.DriverSystem.Entities.Address", "address")
                        .WithMany()
                        .HasForeignKey("AddressID");
                });
#pragma warning restore 612, 618
        }
    }
}
