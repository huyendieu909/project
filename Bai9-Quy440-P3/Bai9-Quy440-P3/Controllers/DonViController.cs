using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_Quy440_P3.Controllers
{
    public class DonViController : ApiController
    {
        [HttpGet]
        public List<DonVi> LayDanhSachDonVi()
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<DonVi> dv = db.DonVis.ToList();
                return dv;
            }
        }
        [HttpGet]
        public DonVi LayChiTiet1DonVi(string madv)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                DonVi dv = db.DonVis.FirstOrDefault(x => x.MaDonVi.Equals(madv));
                return dv;
            }
        }
        [HttpPost]
        public IHttpActionResult Save([FromBody] DonVi donvi)
        {
            using (QLLuongContext db = new QLLuongContext())
            { 
                db.DonVis.Add(donvi);
                db.SaveChanges();   
            }
            return Ok("Du lieu da duoc them");
        }
    }
}
