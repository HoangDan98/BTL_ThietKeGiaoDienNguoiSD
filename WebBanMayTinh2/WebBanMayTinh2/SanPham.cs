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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public string ID { get; set; }
        public string IDLoaiSanPham { get; set; }
        public string SoSeri { get; set; }
        public string IDCoSo { get; set; }
        public string IDTrangThai { get; set; }
    
        public virtual CoSo CoSo { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual TrangThaiSP TrangThaiSP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
