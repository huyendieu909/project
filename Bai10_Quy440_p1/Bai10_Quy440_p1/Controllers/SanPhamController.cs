using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai10_Quy440_p1.Cotrollers
{
    public class SanPhamController : ApiController
    {
        [HttpGet]
        public List<SanPham> LayToanBoSanPham()
        {
            CSDLQLBanHangDataContext db = new CSDLQLBanHangDataContext();   
            List<SanPham> sp = db.SanPhams.ToList();
            foreach (SanPham s in sp)
            {
                s.DanhMuc = null;
            }
            return sp;
        }

        [HttpGet]
        public SanPham LaySanPham(string id)
        {
            CSDLQLBanHangDataContext db = new CSDLQLBanHangDataContext();
            SanPham sp = db.SanPhams.First(x => x.Ma.Equals(id));
            if (sp != null)
            {
                sp.DanhMuc = null;
            }
            return sp;
        }
    }
}
