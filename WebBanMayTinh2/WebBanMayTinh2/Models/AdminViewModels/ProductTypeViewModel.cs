using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class ProductTypeViewModel
    {
        public SelectList NhaCungCaps { get; set; }
        public SelectList DanhMucs { get; set; }
        public SelectList Anhs { get; set; }
        public LoaiSanPham LoaiSanPhamProp { get; set; }
        //public int SoLuongTrongKho { get; set; }
        //public int SoLuongDaBan { get; set; }
    }
}