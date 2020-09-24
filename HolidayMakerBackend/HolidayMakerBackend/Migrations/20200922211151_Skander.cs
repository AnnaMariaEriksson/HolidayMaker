using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class Skander : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Booking",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelID",
                keyValue: 1,
                columns: new[] { "HasRestaurant", "HotelDescription" },
                values: new object[] { true, "Ett fint hotell" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Booking");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelID",
                keyValue: 1,
                columns: new[] { "HasRestaurant", "HotelDescription" },
                values: new object[] { false, null });
        }
    }
}
