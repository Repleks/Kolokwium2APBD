﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrzykladoweGago.Contexts;

#nullable disable

namespace PrzykladoweGago.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrzykladoweGago.Models.BoatStandard", b =>
                {
                    b.Property<int>("IdBoatStandard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBoatStandard"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdBoatStandard");

                    b.ToTable("BoatStandards");

                    b.HasData(
                        new
                        {
                            IdBoatStandard = 1,
                            Level = 1,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdClient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<int>("IdClientCategory")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Pesel");

                    b.HasKey("IdClient");

                    b.HasIndex("IdClientCategory");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Birthday = new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(79),
                            Email = "jankowalski@gmail.com",
                            IdClientCategory = 1,
                            LastName = "Kowalski",
                            Name = "Jan",
                            Pesel = "12345678901"
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.ClientCategory", b =>
                {
                    b.Property<int>("IdClientCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdClientCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientCategory"));

                    b.Property<double>("DiscountPerc")
                        .HasColumnType("float")
                        .HasColumnName("DiscountPerc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdClientCategory");

                    b.ToTable("ClientCategories");

                    b.HasData(
                        new
                        {
                            IdClientCategory = 1,
                            DiscountPerc = 10.0,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdReservation");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<string>("CancelReason")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CancelReason");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateFrom");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateTo");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("bit")
                        .HasColumnName("Fulfilled");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int")
                        .HasColumnName("IdBoatStandard");

                    b.Property<int>("IdClient")
                        .HasColumnType("int")
                        .HasColumnName("IdClient");

                    b.Property<int>("NumOfBoats")
                        .HasColumnType("int")
                        .HasColumnName("NumOfBoats");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.HasKey("IdReservation");

                    b.HasIndex("IdBoatStandard");

                    b.HasIndex("IdClient");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            IdReservation = 1,
                            CancelReason = "Test",
                            Capacity = 1,
                            DateFrom = new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(217),
                            DateTo = new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(221),
                            Fulfilled = false,
                            IdBoatStandard = 1,
                            IdClient = 1,
                            NumOfBoats = 1,
                            Price = 1m
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Sailboat", b =>
                {
                    b.Property<int>("IdSailboat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdSailboat");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSailboat"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Description");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.HasKey("IdSailboat");

                    b.HasIndex("IdBoatStandard");

                    b.ToTable("Sailboat");

                    b.HasData(
                        new
                        {
                            IdSailboat = 1,
                            Capacity = 10,
                            Description = "Test",
                            IdBoatStandard = 1,
                            Name = "Test",
                            Price = 100m
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.SailboatReservation", b =>
                {
                    b.Property<int>("IdSailboat")
                        .HasColumnType("int")
                        .HasColumnName("IdSailboat");

                    b.Property<int>("IdReservation")
                        .HasColumnType("int")
                        .HasColumnName("IdReservation");

                    b.HasKey("IdSailboat", "IdReservation");

                    b.HasIndex("IdReservation");

                    b.ToTable("SailboatReservation");

                    b.HasData(
                        new
                        {
                            IdSailboat = 1,
                            IdReservation = 1
                        });
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Client", b =>
                {
                    b.HasOne("PrzykladoweGago.Models.ClientCategory", "ClientCategory")
                        .WithMany("Clients")
                        .HasForeignKey("IdClientCategory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientCategory");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Reservation", b =>
                {
                    b.HasOne("PrzykladoweGago.Models.BoatStandard", "BoatStandard")
                        .WithMany("Reservations")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PrzykladoweGago.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BoatStandard");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Sailboat", b =>
                {
                    b.HasOne("PrzykladoweGago.Models.BoatStandard", "BoatStandard")
                        .WithMany("Sailboats")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BoatStandard");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.SailboatReservation", b =>
                {
                    b.HasOne("PrzykladoweGago.Models.Reservation", "Reservation")
                        .WithMany("SailboatReservations")
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PrzykladoweGago.Models.Sailboat", "Sailboat")
                        .WithMany("SailboatReservations")
                        .HasForeignKey("IdSailboat")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Sailboat");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.BoatStandard", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Sailboats");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.ClientCategory", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Reservation", b =>
                {
                    b.Navigation("SailboatReservations");
                });

            modelBuilder.Entity("PrzykladoweGago.Models.Sailboat", b =>
                {
                    b.Navigation("SailboatReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
