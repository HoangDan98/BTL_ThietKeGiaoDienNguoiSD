using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanMayTinh.Controllers
{
    public class DropBoxController : Controller
    {
        DBContext context = new DBContext();
        // GET: DropBox
        public PartialViewResult Index()
        {
            SelectList danhSachSanPham = new SelectList(context.DanhMucSPs, "Ten", "ID");
            return PartialView(danhSachSanPham);
        }
    }
}