using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayMakerBackend.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CityID = table.Column<int>(nullable: false),
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
                    Test2 = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionID",
                table: "City",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityID",
                table: "Hotel",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
