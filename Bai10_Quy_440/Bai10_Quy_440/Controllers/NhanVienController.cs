using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai10_Quy_440.Controllers
{
    public class NhanVienController : ApiController
    {
        [HttpPut]
        public IHttpActionResult Sua([FromBody] NhanVien nv)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nhanVien = db.NhanViens.Find(nv.Ma);
                if (nhanVien != null)
                {
                    nhanVien.Ma = nv.Ma;
                    nhanVien.HoTen = nv.HoTen;
                    nhanVien.NgaySinh = nv.NgaySinh;
                    nhanVien.GioiTinh = nv.GioiTinh;
                    nhanVien.MaDonVi = nv.MaDonVi;
                    nhanVien.DonVi = nv.DonVi;
                    nhanVien.HSLuong = nv.HSLuong;
                    db.SaveChanges();
                }
                else return NotFound();
            }
            return Ok("Du lieu da duoc sua");
        }
        [HttpDelete]
        public IHttpActionResult Xoa(string ma)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Ma.Equals(ma));
                if (nv != null)
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                } else return NotFound();
            }
            return Ok("Du lieu da duoc xoa");
        }



        [HttpGet]
        public List<NhanVien> ShowAll()
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<NhanVien> nv = db.NhanViens.ToList();
                return nv;
            }
        }
    }
}
