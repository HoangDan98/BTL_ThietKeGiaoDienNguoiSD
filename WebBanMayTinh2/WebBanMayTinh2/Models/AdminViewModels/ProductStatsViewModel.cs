using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class ProductStatsViewModel
    {
        public SelectList Branches { get; set; }
        public SelectList Supplieres { get; set; }
        public SelectList Categories { get; set; }
        public IEnumerable<SanPham> Products { get; set; }
        public int TotalMoneys { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}