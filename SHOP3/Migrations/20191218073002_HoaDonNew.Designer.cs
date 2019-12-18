﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SHOP3.Models;

namespace SHOP3.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20191218073002_HoaDonNew")]
    partial class HoaDonNew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SHOP3.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("MaHD");

                    b.Property<int>("Gia");

                    b.Property<int>("MaHH");

                    b.Property<int>("SoLuong");

                    b.HasKey("MaHD");

                    b.HasIndex("MaHH");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("SHOP3.Models.HangHoa", b =>
                {
                    b.Property<int>("MaHh")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGia");

                    b.Property<double>("GiamGia");

                    b.Property<string>("Hinh");

                    b.Property<int>("MaLoai");

                    b.Property<int>("MaTH");

                    b.Property<string>("MoTa");

                    b.Property<string>("TenHh");

                    b.HasKey("MaHh");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaTH");

                    b.ToTable("HangHoas");
                });

            modelBuilder.Entity("SHOP3.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaKhachHang");

                    b.Property<DateTime>("NgayTao");

                    b.HasKey("MaHD");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("SHOP3.Models.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoai");

                    b.HasKey("MaLoai");

                    b.ToTable("Loais");
                });

            modelBuilder.Entity("SHOP3.Models.ThanhVien", b =>
                {
                    b.Property<int>("MaTv")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi");

                    b.Property<string>("DienThoai");

                    b.Property<string>("Email");

                    b.Property<string>("GioiTinh");

                    b.Property<int>("LoaiTv");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("NgaySinh");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TenTv");

                    b.HasKey("MaTv");

                    b.ToTable("ThanhViens");
                });

            modelBuilder.Entity("SHOP3.Models.ThuongHieu", b =>
                {
                    b.Property<int>("MaTH")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenTH");

                    b.HasKey("MaTH");

                    b.ToTable("ThuongHieus");
                });

            modelBuilder.Entity("SHOP3.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("SHOP3.Models.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SHOP3.Models.HangHoa", "HangHoa")
                        .WithMany()
                        .HasForeignKey("MaHH")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SHOP3.Models.HangHoa", b =>
                {
                    b.HasOne("SHOP3.Models.Loai", "Loai")
                        .WithMany()
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SHOP3.Models.ThuongHieu", "ThuongHieu")
                        .WithMany()
                        .HasForeignKey("MaTH")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
