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
    
    public partial class TRA_SACH
    {
        public int MaPhieuTra { get; set; }
        public Nullable<int> MaPhieuMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public Nullable<int> TienPhat { get; set; }
    
        public virtual PHIEU_MUON_SACH PHIEU_MUON_SACH { get; set; }
    }
}
