using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfRegion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
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
                    table.ForeignKey(
                        name: "FK_City_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ExtraBed = table.Column<bool>(nullable: false),
                    HasAllInclusive = table.Column<bool>(nullable: false),
                    IsAllInclusive = table.Column<bool>(nullable: false),
                    HasFullBoard = table.Column<bool>(nullable: false),
                    HasHalfBoard = table.Column<bool>(nullable: false),
                    RoomName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "RegionID", "NameOfRegion" },
                values: new object[] { 1, "Skåne" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "bosse@123.se", "Bosse", "Larsson", "hejhej" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "NameOfCity", "RegionID" },
                values: new object[] { 1, "Malmö", 1 });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelID", "CityID", "DistansToBeach", "DistansToCenter", "FilterReset", "HasAllInclusive", "HasChildrensClub", "HasEntertainment", "HasFullBoard", "HasHalfBoard", "HasPool", "HasRestaurant", "HotelDescription", "Name", "Test", "Test2" },
                values: new object[] { 1, 1, 20, 1, true, true, false, true, false, false, true, false, null, "Bosses hotell", true, true });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "ExtraBed", "HasAllInclusive", "HasFullBoard", "HasHalfBoard", "HotelID", "IsAllInclusive", "Price", "RoomName" },
                values: new object[] { 1, true, true, false, false, 1, true, 300, "Rum 1" });

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionID",
                table: "City",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityID",
                table: "Hotel",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelID",
                table: "Room",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
