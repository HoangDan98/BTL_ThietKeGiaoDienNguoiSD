using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models.AdminViewModels;

namespace WebBanMayTinh.Controllers
{
    public class AdminProductTypeController : Controller
    {
        DBContext dbContext = new DBContext();
        int itemPerPage = 5;
        // GET: AdminProductType
        public ActionResult Index(int page = 1)
        {
            ViewBag.Heading = "Tất cả loại sản phẩm";
            ProductTypeList productList = new ProductTypeList()
            {
                CurrentCategoryNav = "AdminProductType",
                ProductTypes = dbContext.LoaiSanPhams.OrderBy(p => p.ID).Skip((page - 1) * itemPerPage).Take(itemPerPage),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = itemPerPage,
                    TotalItems = dbContext.LoaiSanPhams.Count()
                }
            };
            return View(productList);
        }

        public ActionResult Edit(string productTypeId)
        {
            LoaiSanPham loaiSanPham = dbContext.LoaiSanPhams.FirstOrDefault(sp => sp.ID == productTypeId);
            if (loaiSanPham == null)
            {
                System.Diagnostics.Debug.WriteLine("San pham is Null: " + productTypeId.Length);
            }
            ProductTypeViewModel productTypeVM = new ProductTypeViewModel
            {
                DanhMucs = new SelectList(dbContext.DanhMucSPs, "ID", "Ten", loaiSanPham.DanhMucSP.ID),
                LoaiSanPhamProp = loaiSanPham,
                NhaCungCaps = new SelectList(dbContext.NhaCungCaps, "ID", "Ten", loaiSanPham.NhaCungCap.ID),
                Anhs = new SelectList(new List<string> { "product01.png", "product02.png", "product03.png", "product04.png", "product05.png", "product06.png", "product07.png", "product08.png" }, loaiSanPham.Anh),
                //SoLuongDaBan = dbContext.SanPhams.Select(sp => sp.LoaiSanPham.ID == productTypeId && (sp.TrangThaiSP.ID == "4" || sp.TrangThaiSP.ID == "3")).Count(),
                //SoLuongTrongKho = dbContext.SanPhams.Select(sp => sp.LoaiSanPham.ID == productTypeId && sp.TrangThaiSP.ID == "1").Count(),
            };
            return View(productTypeVM);
        }

        [HttpPost]
        public ActionResult Edit(LoaiSanPham productType)
        {
            if (productType.ID == null)
            {
                System.Diagnostics.Debug.WriteLine("In id == : " + productType.ID);
                productType.ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                dbContext.LoaiSanPhams.Add(productType);
                dbContext.SaveChanges();
            }
            else
            {
                LoaiSanPham dbProductType = dbContext.LoaiSanPhams.Find(productType.ID);
                if (dbProductType != null)
                {
                    dbProductType.Ten = productType.Ten;
                    dbProductType.MoTa = productType.MoTa;
                    dbProductType.Gia = productType.Gia;
                    dbProductType.IDNhaCungCap = productType.IDNhaCungCap;
                    dbProductType.IDDanhMucSP= productType.IDDanhMucSP;
                    dbProductType.GiamGia = productType.GiamGia;
                    dbProductType.Anh = productType.Anh;
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string productTypeId)
        {
            LoaiSanPham productType = dbContext.LoaiSanPhams.Find(productTypeId);
            if (productType != null)
            {
                dbContext.LoaiSanPhams.Remove(productType);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            LoaiSanPham productType = new LoaiSanPham();
            productType.ID = null;
            ProductTypeViewModel productTypeVM = new ProductTypeViewModel()
            {
                DanhMucs = new SelectList(dbContext.DanhMucSPs, "ID", "Ten", dbContext.LoaiSanPhams.First().ID),
                LoaiSanPhamProp = productType,
                NhaCungCaps = new SelectList(dbContext.NhaCungCaps, "ID", "Ten", dbContext.NhaCungCaps.First().ID),
                Anhs = new SelectList(new List<string> { "product01.png", "product02.png", "product03.png", "product04.png", "product05.png", "product06.png", "product07.png", "product08.png" }, "product01.png")
            };
            return View("Edit", productTypeVM);
        }

        public ActionResult Detail(string productTypeID, int page = 1)
        {
            LoaiSanPham productType = dbContext.LoaiSanPhams.Find(productTypeID);
            int? totalStars = dbContext.DanhGiaSps
                .Where(item => item.IDLoaiSanPham == productTypeID)
                .Sum(item => item.DanhGia);
            float averageStar = 0;
            if (totalStars.HasValue)
            {
                averageStar = totalStars.Value / (float)dbContext.DanhGiaSps
                .Where(sp => sp.IDLoaiSanPham == productTypeID).Count();
            }
            int selledProductCount = dbContext.SanPhams.Where(sp => sp.IDLoaiSanPham == productTypeID && sp.IDTrangThai == "2")
                .Count();
            int remainProductCount = dbContext.SanPhams.Where(sp => sp.IDLoaiSanPham == productTypeID && sp.IDTrangThai == "1").Count();
            IEnumerable<BinhLuanSp> comments = dbContext.BinhLuanSps.Where(blsp => blsp.IDLoaiSanPham == productTypeID).OrderBy(blsp =>blsp.IDNguoiDung).ToList();
           // System.Diagnostics.Debug.WriteLine("Total comments: " + comments.Count());
            ProductTypeDetail productTypeDetail = new ProductTypeDetail
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = 5,
                    TotalItems = comments.Count()
                },
                ProductType = productType,
                AverageStar = averageStar,
                Comments = comments.Skip((page - 1) * 5).Take(5),
                SelledProductCount = selledProductCount,
                RemainProductCount = remainProductCount
            };
            return View(productTypeDetail);
        }

        public ActionResult DeleteComment(string userID, string productTypeID, string returnUrl)
        {
            BinhLuanSp comment = dbContext.BinhLuanSps.FirstOrDefault(cm => cm.IDLoaiSanPham == productTypeID && cm.IDNguoiDung == userID);
            if (comment != null)
            {
                dbContext.BinhLuanSps.Remove(comment);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Detail", new { productTypeID = productTypeID });
        }
    }
}