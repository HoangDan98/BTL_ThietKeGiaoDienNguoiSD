using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class ProductTypeItem
    {
        public LoaiSanPham ProductType { get; set; }
        public int SelledProductCount { get; set; }
        public int RemainProductCount { get; set; }
    }
    public class ProductTypeList
    {
        public IEnumerable<LoaiSanPham> ProductTypes;
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategoryNav { get; set; }
    }
}