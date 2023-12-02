using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai10_Quy_440.Controllers
{
    public class DonViController : ApiController
    {
        [HttpPut]
        public IHttpActionResult Sua([FromBody] DonVi dv)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                DonVi donVi = db.DonVis.Find(dv.MaDonVi);
                if (donVi != null)
                {
                    donVi.MaDonVi = dv.MaDonVi;
                    donVi.TenDonVi = dv.TenDonVi;
                    db.SaveChanges();
                }
                else return NotFound();
            }
            return Ok("Du lieu da duoc sua");
        }
        [HttpDelete]
        public IHttpActionResult Delete(string madonvi)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                DonVi dv = db.DonVis.FirstOrDefault(d =>  d.MaDonVi == madonvi);
                if (dv != null)
                {
                    db.DonVis.Remove(dv);
                    db.SaveChanges();
                } else return NotFound();
            }
            return Ok("Du lieu da duoc xoa");
        }



        [HttpGet]
        public List<DonVi> DonViGet()
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                List<DonVi> dv = db.DonVis.ToList();
                return dv;
            }
        }
    }
}
