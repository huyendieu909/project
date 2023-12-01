using System;
using System.Collections.Generic;

namespace Bai11_Quy440_P3.QLBanHang;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateOnly? NgayLap { get; set; }

    public string? MaKh { get; set; }

    public string? NguoiLap { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual KhachHang? MaKhNavigation { get; set; }
}
