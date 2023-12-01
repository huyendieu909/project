using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_Quy440_P3.Controllers
{
    public class NhanVienController : ApiController
    {
        [HttpGet]
        public List<NhanVien> LayAllNhanVien()
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<NhanVien> nv = db.NhanViens.ToList();
                return nv;
            }
        }

        [HttpGet]
        public NhanVien LayChiTiet1NV(string ma)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma.Equals(ma));
                return nv;
            }
        }

        [HttpGet]
        public List<NhanVien> LayDanhSachNhanVienTheoDonVi(string madv)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<NhanVien> nv = db.NhanViens.Where(x => x.MaDonVi.Equals(madv)).ToList();
                return nv;
            }
        }

        [HttpGet]
        public List<NhanVien> LayDanhSachNhanVienTheoGioiTinh (string gender)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<NhanVien> nv = db.NhanViens.Where(x => x.GioiTinh.Equals(gender)).ToList();
                return nv;
            }
        }

        [HttpGet] 
        public List<NhanVien> LayDanhSachNhanVienTheoHSLuong (int a, int b)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<NhanVien> nv = db.NhanViens.Where(x => x.HSLuong >= a &&  x.HSLuong <= b).ToList();
                return nv;
            }
        }
        [HttpPost]        
        public IHttpActionResult Save([FromBody] NhanVien nv)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
            }
            return Ok("Du lieu da duoc them");            
        }

        [HttpDelete]
        public IHttpActionResult Delete(string ma)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma.Equals(ma));
                if (nv != null)
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                }
                else return NotFound();
            }
            return Ok("Du lieu da duoc xoa");
        }
    }
}
