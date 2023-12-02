using System;
using System.Collections.Generic;

namespace Bai11TH_Quy_440.QLNhanSu;

public partial class PhongBan
{
    public string MaPb { get; set; } = null!;

    public string? TenPb { get; set; }

    public DateOnly? NgayThanhLap { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
