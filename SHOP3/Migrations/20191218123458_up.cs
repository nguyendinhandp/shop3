using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOP3.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_MaHD",
                table: "ChiTietHoaDon");

            migrationBuilder.AddColumn<int>(
                name: "ThanhVienMaTv",
                table: "HoaDon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoaDonMaHD",
                table: "ChiTietHoaDon",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThanhVienMaTv",
                table: "HoaDon",
                column: "ThanhVienMaTv");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_HoaDonMaHD",
                table: "ChiTietHoaDon",
                column: "HoaDonMaHD");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHD",
                table: "ChiTietHoaDon",
                column: "HoaDonMaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ThanhViens_ThanhVienMaTv",
                table: "HoaDon",
                column: "ThanhVienMaTv",
                principalTable: "ThanhViens",
                principalColumn: "MaTv",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ThanhViens_ThanhVienMaTv",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_ThanhVienMaTv",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_HoaDonMaHD",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "ThanhVienMaTv",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "HoaDonMaHD",
                table: "ChiTietHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_MaHD",
                table: "ChiTietHoaDon",
                column: "MaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
