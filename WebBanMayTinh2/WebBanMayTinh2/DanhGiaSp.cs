//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanMayTinh
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGiaSp
    {
        public string IDNguoiDung { get; set; }
        public string IDLoaiSanPham { get; set; }
        public Nullable<int> DanhGia { get; set; }
    
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
