using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models.AdminViewModels;

namespace WebBanMayTinh.Controllers
{
    public class AdminStatsController : Controller
    {
        DBContext dbContext = new DBContext();
        // GET: AdminStats
        public ActionResult Index(string fromDateStr = "", string toDateStr = "", string branchID = "", string supplierID = "", string categoryID = "", int page = 1)
        {
            DateTime fromDate, toDate;
            DateTime.TryParse(fromDateStr, out fromDate);
            DateTime.TryParse(fromDateStr, out toDate);
            if (branchID == null)
            {
                System.Diagnostics.Debug.WriteLine("Is null");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Length: " + branchID.Length);
            }
            IEnumerable<SanPham> products = dbContext.SanPhams
                .Where(pd => (fromDateStr == "" || pd.HoaDon.NgayXuatHD >= fromDate)
                && (toDateStr == "" || pd.HoaDon.NgayXuatHD <= toDate)
                && (branchID == "" || pd.CoSo.ID == branchID)
                && (supplierID == "" || pd.LoaiSanPham.NhaCungCap.ID == supplierID)
                && (categoryID == ""  || pd.LoaiSanPham.DanhMucSP.ID == categoryID)
                && pd.TrangThaiSP.ID == "2").ToList();
            ProductStatsViewModel productStats = new ProductStatsViewModel
            {
                Products = products,
                Branches = new SelectList(dbContext.CoSoes, "ID", "Ten", (branchID == null ? dbContext.CoSoes.First().ID : branchID)),
                Categories = new SelectList(dbContext.DanhMucSPs, "ID", "Ten", (categoryID == null ? dbContext.DanhMucSPs.First().ID : categoryID)),
                Supplieres = new SelectList(dbContext.NhaCungCaps, "ID", "Ten", (supplierID == null ? dbContext.NhaCungCaps.First().ID : supplierID)),
                TotalMoneys = products.Sum(pd => pd.LoaiSanPham.Gia).Value,
            };
            return View(productStats);
        }
    }
}