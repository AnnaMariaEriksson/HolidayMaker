using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class SomeTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "RegionID", "NameOfRegion" },
                values: new object[] { 1, "Skåne" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "NameOfCity", "RegionID" },
                values: new object[] { 1, "Malmö", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "RegionID",
                keyValue: 1);
        }
    }
}
