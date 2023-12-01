using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTx.Net2
{
    internal class NhanVien
    {
        public string MaNV {  get; set; }   
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string PhongBan {  get; set; }
        public double HeSoLuong { get; set; }
        public int Tuoi
        {
            get
            {
                return DateTime.Now.Year - NgaySinh.Year;
            }
        }
    }
}
