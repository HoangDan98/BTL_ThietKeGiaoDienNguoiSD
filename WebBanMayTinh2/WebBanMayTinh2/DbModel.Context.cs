﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanMayTinh
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BinhLuanSp> BinhLuanSps { get; set; }
        public virtual DbSet<CauHinhSP> CauHinhSPs { get; set; }
        public virtual DbSet<CoSo> CoSoes { get; set; }
        public virtual DbSet<DanhGiaSp> DanhGiaSps { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<DonViGiaoHang> DonViGiaoHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NguoiGiaoHang> NguoiGiaoHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TrangThaiHoaDon> TrangThaiHoaDons { get; set; }
        public virtual DbSet<TrangThaiSP> TrangThaiSPs { get; set; }
    }
}
