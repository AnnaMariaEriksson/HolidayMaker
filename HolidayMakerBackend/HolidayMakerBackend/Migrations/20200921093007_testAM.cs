using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class testAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelID", "CityID", "DistansToBeach", "DistansToCenter", "FilterReset", "HasAllInclusive", "HasChildrensClub", "HasEntertainment", "HasFullBoard", "HasHalfBoard", "HasPool", "HasRestaurant", "HotelDescription", "Name", "Test", "Test2" },
                values: new object[] { 1, 1, 20, 1, true, true, false, true, false, false, true, false, null, "Bosses hotell", true, true });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "bosse@123.se", "Bosse", "Larsson", "hejhej" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "ExtraBed", "HasAllInclusive", "HasFullBoard", "HasHalfBoard", "HotelID", "IsAllInclusive", "Price", "RoomName" },
                values: new object[] { 1, true, true, false, false, 1, true, 300, "Rum 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "HotelID",
                keyValue: 1);
        }
    }
}
