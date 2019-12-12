using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class ProductList
    {
        public IEnumerable<SanPham> Products;
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategoryNav { get; set; }
    }
}