//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanlyThuVienCuaHung.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            this.BAOCAOMUONSACHes = new HashSet<BAOCAOMUONSACH>();
            this.BAOCAOSACHTRATREs = new HashSet<BAOCAOSACHTRATRE>();
            this.MUONs = new HashSet<MUON>();
            this.PHIEU_MUON_SACH = new HashSet<PHIEU_MUON_SACH>();
        }
    
        public int MaSach { get; set; }
        public Nullable<int> MaTG { get; set; }
        public Nullable<int> MaLoaiSach { get; set; }
        public string TenSach { get; set; }
        public Nullable<int> NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public Nullable<int> HanTra { get; set; }
        public string TinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOCAOMUONSACH> BAOCAOMUONSACHes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOCAOSACHTRATRE> BAOCAOSACHTRATREs { get; set; }
        public virtual LOAI_SACH LOAI_SACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUON> MUONs { get; set; }
        public virtual TAC_GIA TAC_GIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEU_MUON_SACH> PHIEU_MUON_SACH { get; set; }
    }
}
