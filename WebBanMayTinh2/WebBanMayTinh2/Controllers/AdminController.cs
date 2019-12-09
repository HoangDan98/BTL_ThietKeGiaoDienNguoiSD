using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models.AdminViewModels;
namespace WebBanMayTinh.Controllers
{
    public class AdminController : Controller
    {
        DBContext dbContext = new DBContext();
        // GET: Admin
        public ActionResult Index()
        {
            //System.Diagnostics.Debug.WriteLine("Length: " + dbContext.SanPhams.Count());
            return View(dbContext.SanPhams);
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
            sanPhamVM.coSos = new SelectList(dbContext.CoSoes, "ID", "Ten", sanPhamVM.sanPham.CoSo.ID);
            sanPhamVM.loaiSanPhams = new SelectList(dbContext.LoaiSanPhams, "ID", "Ten", sanPham.LoaiSanPham.ID);
            sanPhamVM.trangThais = new SelectList(dbContext.TrangThaiSPs, "ID", "TenTT", sanPham.TrangThaiSP.ID);
            return View(sanPhamVM);
        }

        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            SanPham dbSanPham = dbContext.SanPhams.Find(sanPham.ID);
            if (dbSanPham != null)
            {
                dbSanPham.SoSeri = sanPham.SoSeri;
                dbSanPham.IDCoSo = sanPham.IDCoSo;
                dbSanPham.IDTrangThai = sanPham.IDTrangThai;
                dbContext.SaveChanges();
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
    }
}