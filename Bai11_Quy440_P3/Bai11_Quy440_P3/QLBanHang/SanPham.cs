using System;
using System.Collections.Generic;

namespace Bai11_Quy440_P3.QLBanHang;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public string? MaLoai { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual LoaiSanPham? MaLoaiNavigation { get; set; }
}
