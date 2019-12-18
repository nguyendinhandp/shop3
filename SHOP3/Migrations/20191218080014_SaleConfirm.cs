using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOP3.Migrations
{
    public partial class SaleConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "XacNhan",
                table: "HoaDon",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XacNhan",
                table: "HoaDon");
        }
    }
}
