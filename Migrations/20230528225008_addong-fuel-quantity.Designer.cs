﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rent_a_car_be.Data;

#nullable disable

namespace rent_a_car_be.Migrations
{
    [DbContext(typeof(rent_a_car_beContext))]
    [Migration("20230528225008_addong-fuel-quantity")]
    partial class addongfuelquantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("rent_a_car_be.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarFuelId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoChasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoPlaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarFuelId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarTypeId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarBrand");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarFuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarFuel");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarInspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BottomLeftWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("BottomRightWheel")
                        .HasColumnType("bit");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<int>("FuelQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("HasGato")
                        .HasColumnType("bit");

                    b.Property<bool>("HasGlassBreaks")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSpareWheel")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsScratched")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TopLeftWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("TopRightWheel")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CarInspection");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreditCard")
                        .HasColumnType("int");

                    b.Property<int>("CreditLimit")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommissionPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("rent_a_car_be.Models.RentAndReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountDay")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CarInspectionId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CarInspectionId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("RentAndReturn");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Car", b =>
                {
                    b.HasOne("rent_a_car_be.Models.CarFuel", "CarFuel")
                        .WithMany("Cars")
                        .HasForeignKey("CarFuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarFuel");

                    b.Navigation("CarModel");

                    b.Navigation("CarType");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarInspection", b =>
                {
                    b.HasOne("rent_a_car_be.Models.Car", "Car")
                        .WithMany("Inspections")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.Client", "Client")
                        .WithMany("Inspections")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.Employee", "Employee")
                        .WithMany("Inspections")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarModel", b =>
                {
                    b.HasOne("rent_a_car_be.Models.CarBrand", "CarBrand")
                        .WithMany("Models")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("rent_a_car_be.Models.RentAndReturn", b =>
                {
                    b.HasOne("rent_a_car_be.Models.Car", "Car")
                        .WithMany("RentsAndReturns")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.CarInspection", "CarInspection")
                        .WithMany("RentsAndReturns")
                        .HasForeignKey("CarInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.Client", "Client")
                        .WithMany("RentsAndReturns")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rent_a_car_be.Models.Employee", "Employee")
                        .WithMany("RentsAndReturns")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("CarInspection");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Car", b =>
                {
                    b.Navigation("Inspections");

                    b.Navigation("RentsAndReturns");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarBrand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarFuel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarInspection", b =>
                {
                    b.Navigation("RentsAndReturns");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("rent_a_car_be.Models.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Client", b =>
                {
                    b.Navigation("Inspections");

                    b.Navigation("RentsAndReturns");
                });

            modelBuilder.Entity("rent_a_car_be.Models.Employee", b =>
                {
                    b.Navigation("Inspections");

                    b.Navigation("RentsAndReturns");
                });
#pragma warning restore 612, 618
        }
    }
}
