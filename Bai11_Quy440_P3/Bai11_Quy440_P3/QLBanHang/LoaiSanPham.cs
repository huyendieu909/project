using System;
using System.Collections.Generic;

namespace Bai11_Quy440_P3.QLBanHang;

public partial class LoaiSanPham
{
    public string MaLoai { get; set; } = null!;

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
