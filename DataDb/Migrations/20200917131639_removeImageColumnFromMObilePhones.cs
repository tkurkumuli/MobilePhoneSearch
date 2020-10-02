using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class removeImageColumnFromMObilePhones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "MobilePhones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MobilePhones",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MobilePhones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://img.zoommer.ge/zoommer-images/thumbs/0110804_samsung-galaxy-a01-2gb-ram-16gb-lte-a015fd-black_550.png");

            migrationBuilder.UpdateData(
                table: "MobilePhones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://img.zoommer.ge/zoommer-images/thumbs/0103604_huawei-p-smart-z-4gb-ram-64gb-lte-black_220.png");

            migrationBuilder.UpdateData(
                table: "MobilePhones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://img.zoommer.ge/zoommer-images/thumbs/0107238_apple-iphone-11-pro-single-sim-256gb-grey_220.png");

            migrationBuilder.UpdateData(
                table: "MobilePhones",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://img.zoommer.ge/zoommer-images/thumbs/0107688_xiaomi-redmi-note-8t-global-version-4gb-ram-64gb-lte-grey_220.png");

            migrationBuilder.UpdateData(
                table: "MobilePhones",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://img.zoommer.ge/zoommer-images/thumbs/0107222_oneplus-7t-pro-dual-sim-8gb-ram-256gb-lte-haze-blue_220.png");
        }
    }
}
