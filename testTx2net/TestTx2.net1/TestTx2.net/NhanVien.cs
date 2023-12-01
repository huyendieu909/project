using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTx2.net
{
    internal class NhanVien
    {
        public NhanVien() { }   
        public string? MaNV {  get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public string? PhongBan { get; set; }
        public DateTime NgaySinh { get; set; }
        public Double HeSoLuong { get; set; }
        public int Tuoi
        {
            get
            {
                return DateTime.Now.Year - NgaySinh.Year;
            }
        }
    }
}
