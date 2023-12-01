using System;
using System.Collections.Generic;

namespace WpfApp1.QLPhongBan;

public partial class PhongBan
{
    public string MaPb { get; set; } = null!;

    public string? TenPb { get; set; }

    public string? NgayThanhLap { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
