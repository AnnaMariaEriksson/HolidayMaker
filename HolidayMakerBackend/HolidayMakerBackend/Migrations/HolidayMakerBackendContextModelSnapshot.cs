﻿// <auto-generated />
using System;
using HolidayMakerBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HolidayMakerBackend.Migrations
{
    [DbContext(typeof(HolidayMakerBackendContext))]
    partial class HolidayMakerBackendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

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

                    b.HasKey("RoomID");

                    b.HasIndex("BookingID");

                    b.HasIndex("HotelID");

                    b.ToTable("Room");
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
                });

            modelBuilder.Entity("HolidayMakerBackend.Models.Room", b =>
                {
                    b.HasOne("HolidayMakerBackend.Models.Booking", null)
                        .WithMany("BookingRooms")
                        .HasForeignKey("BookingID");

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
