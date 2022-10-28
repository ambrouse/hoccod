using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fantaysWeb.Models
{
    public class donHang
    {
        public int ID { get; set; }
        public string TenKH { get; set; }     
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayDat { get; set; }

        public List<Truyen> ChitietDH = new List<Truyen>();

    }
}