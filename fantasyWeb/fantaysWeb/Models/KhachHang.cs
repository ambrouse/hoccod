//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fantaysWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        public int ID { get; set; }
        public string TenKH { get; set; }
        public Nullable<int> SoDT { get; set; }
        public Nullable<int> IDKH { get; set; }
    
        public virtual LoaiKhachHang LoaiKhachHang { get; set; }
    }
}