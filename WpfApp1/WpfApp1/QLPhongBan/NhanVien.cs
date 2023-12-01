using System;
using System.Collections.Generic;

namespace WpfApp1.QLPhongBan;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? MaPb { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }
}
