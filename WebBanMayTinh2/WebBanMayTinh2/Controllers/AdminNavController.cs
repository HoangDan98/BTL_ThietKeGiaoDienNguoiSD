using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanMayTinh.Controllers
{
    public class NavCategoryItem
    {
        public string Name { get; set; }
        public string ControllerName { get; set; }
    }
    public class AdminNavController : Controller
    {
        List<NavCategoryItem> navCategories = new List<NavCategoryItem>
        {
            new NavCategoryItem
            {
                Name = "Sản phẩm",
                ControllerName = "AdminProduct"
            },
            new NavCategoryItem
            {
                Name = "Loại sản phẩm",
                ControllerName = "AdminProductType"
            },
            new NavCategoryItem
            {
                Name = "Thống kê",
                ControllerName = "AdminStats"
            },
            new NavCategoryItem
            {
                Name = "Nhà cung cấp",
                ControllerName = "AdminProduct"
            },
            new NavCategoryItem
            {
                Name = "Người dùng",
                ControllerName = "AdminProduct"
            },
            new NavCategoryItem
            {
                Name = "Danh mục người dùng",
                ControllerName = "AdminProduct"
            },
            new NavCategoryItem
            {
                Name = "Hóa đơn",
                ControllerName = "AdminProduct"
            },
        };
        // GET: AdminNav
        public ActionResult Index(string navCategory)
        {
            ViewBag.SelectedCategory = navCategory;
            return PartialView("VerticalMenu", navCategories);
        }
    }
}