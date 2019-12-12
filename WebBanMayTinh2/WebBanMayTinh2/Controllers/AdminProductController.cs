using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models.AdminViewModels;
namespace WebBanMayTinh.Controllers
{
    public class AdminProductController : Controller
    {
        DBContext dbContext = new DBContext();
        int itemPerPage = 5;
        // GET: Admin
        public ActionResult Index(int page = 1)
        {
            ProductList productList = new ProductList()
            {
                CurrentCategoryNav = "AdminProduct",
                Products = dbContext.SanPhams.OrderBy(p => p.ID).Skip((page - 1) * itemPerPage).Take(itemPerPage),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = itemPerPage,
                    TotalItems = dbContext.SanPhams.Count()
                }
            };
            return View(productList);
        }

        public ActionResult Edit(string productId)
        {
            SanPham sanPham = dbContext.SanPhams.FirstOrDefault(sp => sp.ID == productId);
            if (sanPham == null)
            {
                System.Diagnostics.Debug.WriteLine("San pham is Null: " + productId.Length);
            }
            SanPhamViewModel sanPhamVM = new SanPhamViewModel();
            sanPhamVM.sanPham = sanPham;
            sanPhamVM.coSos = new SelectList(dbContext.CoSoes, "ID", "Ten", sanPham.CoSo.ID);
            sanPhamVM.loaiSanPhams = new SelectList(dbContext.LoaiSanPhams, "ID", "Ten", sanPham.LoaiSanPham.ID);
            sanPhamVM.trangThais = new SelectList(dbContext.TrangThaiSPs, "ID", "TenTT", sanPham.TrangThaiSP.ID);
            return View(sanPhamVM);
        }

        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            if (sanPham.ID == null)
            {
                System.Diagnostics.Debug.WriteLine("In id == : " + sanPham.ID);
                sanPham.ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                dbContext.SanPhams.Add(sanPham);
                dbContext.SaveChanges();
            } else
            {
                SanPham dbSanPham = dbContext.SanPhams.Find(sanPham.ID);
                if (dbSanPham != null)
                {
                    dbSanPham.SoSeri = sanPham.SoSeri;
                    dbSanPham.IDCoSo = sanPham.IDCoSo;
                    dbSanPham.IDTrangThai = sanPham.IDTrangThai;
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string productId)
        {
            SanPham sanPham = dbContext.SanPhams.Find(productId);
            if (sanPham != null)
            {
                dbContext.SanPhams.Remove(sanPham);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SanPham sanPham = new SanPham();
            sanPham.ID = null;
            SanPhamViewModel sanPhamVM = new SanPhamViewModel();
            sanPhamVM.sanPham = sanPham;
            sanPhamVM.coSos = new SelectList(dbContext.CoSoes, "ID", "Ten", dbContext.SanPhams.First().CoSo.ID);
            sanPhamVM.loaiSanPhams = new SelectList(dbContext.LoaiSanPhams, "ID", "Ten", dbContext.SanPhams.First().LoaiSanPham.ID);
            sanPhamVM.trangThais = new SelectList(dbContext.TrangThaiSPs, "ID", "TenTT", dbContext.SanPhams.First().TrangThaiSP.ID);
            return View("Edit", sanPhamVM);
        }
    }
}