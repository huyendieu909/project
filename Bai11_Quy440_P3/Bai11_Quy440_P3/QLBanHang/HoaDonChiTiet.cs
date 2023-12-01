using System;
using System.Collections.Generic;

namespace Bai11_Quy440_P3.QLBanHang;

public partial class HoaDonChiTiet
{
    public string MaHd { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int? SoLuongMua { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
