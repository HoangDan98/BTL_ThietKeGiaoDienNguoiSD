using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMayTinh.Models.AdminViewModels
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalItems / (float)ItemsPerPage);
    }
}