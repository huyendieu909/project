using System;
using System.Collections.Generic;

namespace Bai11TH_Quy_440.QLNhanSu;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? NgoaiNgu { get; set; }

    public string? MaPb { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }
}
