using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class ProductTypeDetail
    {
        public IEnumerable<BinhLuanSp> Comments { get; set; }
        public float AverageStar { get; set; }
        public LoaiSanPham ProductType { get; set; }
        public int SelledProductCount { get; set; }
        public int RemainProductCount { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}