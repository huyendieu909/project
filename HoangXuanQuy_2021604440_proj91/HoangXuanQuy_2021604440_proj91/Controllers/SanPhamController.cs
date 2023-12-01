using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HoangXuanQuy_2021604440_proj91.Controllers
{
    public class SanPhamController : ApiController
    {
        [HttpGet]
        public List<SanPham> LaySanPham(int ma)
        {
            sanph context = new CSDLQLBanHangConText();
        }
    }
}
