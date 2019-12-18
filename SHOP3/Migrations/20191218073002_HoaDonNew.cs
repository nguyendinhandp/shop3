using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOP3.Migrations
{
    public partial class HoaDonNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaKhachHang = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false),
                    MaHH = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    Gia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HangHoas_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaHH",
                table: "ChiTietHoaDon",
                column: "MaHH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");
        }
    }
}
