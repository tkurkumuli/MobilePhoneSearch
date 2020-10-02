using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturerName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Size = table.Column<string>(maxLength: 50, nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    ScreeenSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Resolution = table.Column<string>(maxLength: 50, nullable: true),
                    Processor = table.Column<string>(maxLength: 50, nullable: true),
                    Memory = table.Column<string>(maxLength: 50, nullable: true),
                    OperatingSystem = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 500, nullable: true),
                    Video = table.Column<string>(maxLength: 500, nullable: true),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhones_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, "Samsung" },
                    { 2, "Apple" },
                    { 3, "Huawei" },
                    { 4, "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "MobilePhones",
                columns: new[] { "Id", "Image", "ManufacturerId", "Memory", "Name", "OperatingSystem", "Price", "Processor", "Resolution", "ScreeenSize", "Size", "Video", "Weight" },
                values: new object[,]
                {
                    { 1, "https://img.zoommer.ge/zoommer-images/thumbs/0110804_samsung-galaxy-a01-2gb-ram-16gb-lte-a015fd-black_550.png", 1, "16 GB", "Samsung Galaxy Edge", "Android 10.0", 700, "Octa-core", "720 x 1560 pixels", 7m, "146.3 x 70.9 x 8.3 mm", "https://www.youtube.com/watch?v=jZSDYEz6DYU", 120 },
                    { 2, "https://img.zoommer.ge/zoommer-images/thumbs/0103604_huawei-p-smart-z-4gb-ram-64gb-lte-black_220.png", 1, "", "Samsung A", "Android 10.0", 800, "Octa-core", "720 x 1560 pixels", 8m, "146.3 x 70.9 x 8.3 mm", "https://www.youtube.com/watch?v=pQ8G57O6Ecc", 150 },
                    { 3, "https://img.zoommer.ge/zoommer-images/thumbs/0107238_apple-iphone-11-pro-single-sim-256gb-grey_220.png", 2, "", "Iphone 11", "Android 10.0", 500, "Octa-core", "720 x 1560 pixels", 6m, "146.3 x 70.9 x 8.3 mm", "https://www.youtube.com/watch?v=H4p6njjPV_o", 200 },
                    { 4, "https://img.zoommer.ge/zoommer-images/thumbs/0107688_xiaomi-redmi-note-8t-global-version-4gb-ram-64gb-lte-grey_220.png", 2, "", "Iphone X", "Android 10.0", 900, "Octa-core", "720 x 1560 pixels", 5m, "146.3 x 70.9 x 8.3 mm", "https://www.youtube.com/watch?v=6wvxyehsvFI", 180 },
                    { 5, "https://img.zoommer.ge/zoommer-images/thumbs/0107222_oneplus-7t-pro-dual-sim-8gb-ram-256gb-lte-haze-blue_220.png", 3, "", "Huawei P9 lite", "Android 10.0", 300, "Octa-core", "720 x 1560 pixels", 7m, "146.3 x 70.9 x 8.3 mm", "https://www.youtube.com/watch?v=NqMk7eJlnxE", 170 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_ManufacturerId",
                table: "MobilePhones",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobilePhones");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
