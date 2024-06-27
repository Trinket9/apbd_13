﻿// <auto-generated />
using System;
using APBD_13.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBD_13.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240627092626_NewDb")]
    partial class NewDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD_13.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("pesel");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("price");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("APBD_13.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int")
                        .HasColumnName("FK_customer");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2")
                        .HasColumnName("from");

                    b.Property<int>("ReservationStatusID")
                        .HasColumnType("int")
                        .HasColumnName("FK_reservation_status");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2")
                        .HasColumnName("to");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int")
                        .HasColumnName("FK_car");

                    b.HasKey("ReservationID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ReservationStatusID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("APBD_13.Models.ReservationStatus", b =>
                {
                    b.Property<int>("PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nam");

                    b.HasKey("PK");

                    b.ToTable("Reservation_Status");
                });

            modelBuilder.Entity("APBD_13.Models.Vehicle", b =>
                {
                    b.Property<int>("PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK"));

                    b.Property<int>("Doors")
                        .HasColumnType("int")
                        .HasColumnName("num_of_doors");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("model");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int")
                        .HasColumnName("year_of_production");

                    b.Property<int>("Seats")
                        .HasColumnType("int")
                        .HasColumnName("num_of_seats");

                    b.Property<int>("VehicleBrandID")
                        .HasColumnType("int")
                        .HasColumnName("FK_vehicle_brand");

                    b.Property<int>("VehicleTypeID")
                        .HasColumnType("int")
                        .HasColumnName("FK_vehicle_type");

                    b.HasKey("PK");

                    b.HasIndex("VehicleBrandID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("APBD_13.Models.VehicleBrand", b =>
                {
                    b.Property<int>("PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PK");

                    b.ToTable("Vehicle_Brands");
                });

            modelBuilder.Entity("APBD_13.Models.VehicleType", b =>
                {
                    b.Property<int>("PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PK"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PK");

                    b.ToTable("Vehicle_Types");
                });

            modelBuilder.Entity("APBD_13.Models.Reservation", b =>
                {
                    b.HasOne("APBD_13.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_13.Models.ReservationStatus", "ReservationStatus")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_13.Models.Vehicle", "Vehicle")
                        .WithMany("Reservations")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ReservationStatus");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("APBD_13.Models.Vehicle", b =>
                {
                    b.HasOne("APBD_13.Models.VehicleBrand", "VehicleBrand")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleBrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_13.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleBrand");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("APBD_13.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("APBD_13.Models.ReservationStatus", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("APBD_13.Models.Vehicle", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("APBD_13.Models.VehicleBrand", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("APBD_13.Models.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}