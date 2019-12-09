using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models;
namespace WebBanMayTinh.Models.AdminViewModels
{
    public class SanPhamViewModel
    {
        public SelectList loaiSanPhams;
        public SelectList coSos;
        public SelectList trangThais;
        public SanPham sanPham;
    }
}