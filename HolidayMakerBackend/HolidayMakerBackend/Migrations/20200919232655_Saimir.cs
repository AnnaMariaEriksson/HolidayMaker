using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class Saimir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionID = table.Column<int>(nullable: false),
                    NameOfCity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelDescription = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DistansToBeach = table.Column<int>(nullable: false),
                    DistansToCenter = table.Column<int>(nullable: false),
                    HasAllInclusive = table.Column<bool>(nullable: false),
                    HasFullBoard = table.Column<bool>(nullable: false),
                    HasHalfBoard = table.Column<bool>(nullable: false),
                    HasRestaurant = table.Column<bool>(nullable: false),
                    HasChildrensClub = table.Column<bool>(nullable: false),
                    HasEntertainment = table.Column<bool>(nullable: false),
                    HasPool = table.Column<bool>(nullable: false),
                    FilterReset = table.Column<bool>(nullable: false),
                    Test = table.Column<bool>(nullable: false),
                    Test2 = table.Column<bool>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ExtraBed = table.Column<bool>(nullable: false),
                    HasAllInclusive = table.Column<bool>(nullable: false),
                    IsAllInclusive = table.Column<bool>(nullable: false),
                    HasFullBoard = table.Column<bool>(nullable: false),
                    HasHalfBoard = table.Column<bool>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    BookingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingID",
                table: "Room",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelID",
                table: "Room",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
