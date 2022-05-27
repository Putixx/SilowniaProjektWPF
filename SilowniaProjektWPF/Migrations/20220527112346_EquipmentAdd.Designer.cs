﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilowniaProjektWPF.DAL.Contexts;

namespace SilowniaProjektWPF.Migrations
{
    [DbContext(typeof(GymDbContext))]
    [Migration("20220527112346_EquipmentAdd")]
    partial class EquipmentAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("SilowniaProjektWPF.DAL.ModelsDTO.EquipmentDTO", b =>
                {
                    b.Property<Guid>("EquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WarrantyExpireDate")
                        .HasColumnType("TEXT");

                    b.HasKey("EquipmentID");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("SilowniaProjektWPF.DAL.ModelsDTO.ReservationDTO", b =>
                {
                    b.Property<Guid>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("InstructorIndex")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ReservationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("SilowniaProjektWPF.DAL.ModelsDTO.WorkerDTO", b =>
                {
                    b.Property<Guid>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("HourlyCost")
                        .HasColumnType("TEXT");

                    b.Property<string>("InstructorIndex")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialization")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerID");

                    b.ToTable("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}