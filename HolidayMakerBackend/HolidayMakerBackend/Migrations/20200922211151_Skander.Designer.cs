﻿// <auto-generated />
using System;
using HolidayMakerBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HolidayMakerBackend.Migrations
{
    [DbContext(typeof(HolidayMakerBackendContext))]
    [Migration("20200922211151_Skander")]
    partial class Skander
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HolidayMakerBackend.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameOfCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.HasIndex("RegionID");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            NameOfCity = "Malmö",
                            RegionID = 1
                        });
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("DistansToBeach")
                        .HasColumnType("int");

                    b.Property<int>("DistansToCenter")
                        .HasColumnType("int");

                    b.Property<bool>("FilterReset")
                        .HasColumnType("bit");

                    b.Property<bool>("HasAllInclusive")
                        .HasColumnType("bit");

                    b.Property<bool>("HasChildrensClub")
                        .HasColumnType("bit");

                    b.Property<bool>("HasEntertainment")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFullBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHalfBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPool")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRestaurant")
                        .HasColumnType("bit");

                    b.Property<string>("HotelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Test")
                        .HasColumnType("bit");

                    b.Property<bool>("Test2")
                        .HasColumnType("bit");

                    b.HasKey("HotelID");

                    b.HasIndex("CityID");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            HotelID = 1,
                            CityID = 1,
                            DistansToBeach = 20,
                            DistansToCenter = 1,
                            FilterReset = true,
                            HasAllInclusive = true,
                            HasChildrensClub = false,
                            HasEntertainment = true,
                            HasFullBoard = false,
                            HasHalfBoard = false,
                            HasPool = true,
                            HasRestaurant = true,
                            HotelDescription = "Ett fint hotell",
                            Name = "Bosses hotell",
                            Test = true,
                            Test2 = true
                        });
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameOfRegion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionID");

                    b.ToTable("Region");

                    b.HasData(
                        new
                        {
                            RegionID = 1,
                            NameOfRegion = "Skåne"
                        });
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ExtraBed")
                        .HasColumnType("bit");

                    b.Property<bool>("HasAllInclusive")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFullBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHalfBoard")
                        .HasColumnType("bit");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAllInclusive")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ExtraBed = true,
                            HasAllInclusive = true,
                            HasFullBoard = false,
                            HasHalfBoard = false,
                            HotelID = 1,
                            IsAllInclusive = true,
                            Price = 300,
                            RoomName = "Rum 1"
                        });
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "bosse@123.se",
                            FirstName = "Bosse",
                            LastName = "Larsson",
                            Password = "hejhej"
                        });
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.City", b =>
                {
                    b.HasOne("HolidayMakerBackend.Models.Region", null)
                        .WithMany("Cities")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Hotel", b =>
                {
                    b.HasOne("HolidayMakerBackend.Models.City", null)
                        .WithMany("Hotels")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Room", b =>
                {
                    b.HasOne("HolidayMakerBackend.Models.Hotel", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
