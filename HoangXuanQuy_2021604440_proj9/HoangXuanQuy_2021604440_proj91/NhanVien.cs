using System;

public class NhanVien
{
	public string HoTen {  get; set; }
	public DateTime NgaySinh { get; set; }
	public string GioiTinh { get; set; }
	public string NgoaiNgu {  get; set; }
	public string PhongBan { get; set; }
	public NhanVien() { }
	public NhanVien(string hoTen, DateTime ngaySinh, string gioiTinh, string ngoaiNgu, string phongBan)
    {
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        GioiTinh = gioiTinh;
        NgoaiNgu = ngoaiNgu;
        PhongBan = phongBan;
    }
}
