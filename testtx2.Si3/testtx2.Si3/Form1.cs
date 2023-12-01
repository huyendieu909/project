using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testtx2.Si3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<NhanVien> nhanViens = new List<NhanVien>();
        DataUtil dataUtil = new DataUtil();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        public void HienThi()
        {
            nhanViens = dataUtil.Show();
            var query = from n in nhanViens where n.Luong > 1000 select n;
            lbNVLuongTren1000.Text = query.Count().ToString();
            dtgNhanVien.DataSource = dataUtil.Show();
        }
        public bool KiemTraNgoaiLeThem()
        {
            if (dataUtil.MaNVDaTonTai(tbMaNV.Text))
            {
                MessageBox.Show($"Mã nhân viên {tbMaNV.Text} đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMaNV.Focus();
                return false;
            }
            try
            {
                int tuoi = int.Parse(tbTuoi.Text);
            }
            catch
            {
                MessageBox.Show("Tuổi không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbTuoi.Focus();
                return false;
            }
            try
            {
                double luong = Convert.ToDouble(tbLuong.Text);
            }
            catch
            {
                MessageBox.Show("Lương không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbLuong.Focus();
                return false;
            }
            return true;
        }
        public bool KiemTraNgoaiLeSua()
        {
            try
            {
                int tuoi = int.Parse(tbTuoi.Text);
            }
            catch
            {
                MessageBox.Show("Tuổi không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbTuoi.Focus();
                return false;
            }
            try
            {
                double luong = Convert.ToDouble(tbLuong.Text);
            }
            catch
            {
                MessageBox.Show("Lương không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbLuong.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KiemTraNgoaiLeThem())
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = tbMaNV.Text;
                nv.HoTen = tbHoTen.Text;
                nv.Tuoi = int.Parse(tbTuoi.Text);
                nv.Luong = Convert.ToDouble(tbLuong.Text);
                nv.Xa = tbXa.Text;
                nv.Huyen = tbHuyen.Text;
                nv.Tinh = tbTinh.Text;
                nv.DienThoai = tbDienThoai.Text;
                dataUtil.Add(nv);
                HienThi();
            }
        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien nv = dtgNhanVien.CurrentRow.DataBoundItem as NhanVien;
            if (nv != null)
            {
                tbMaNV.Text = nv.MaNV;
                tbHoTen.Text = nv.HoTen;
                tbTuoi.Text = nv.Tuoi.ToString();
                tbLuong.Text = nv.Luong.ToString();
                tbXa.Text = nv.Xa;
                tbHuyen.Text = nv.Huyen;
                tbTinh.Text = nv.Tinh;
                tbDienThoai.Text = nv.DienThoai;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Note", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                dataUtil.Delete(tbMaNV.Text);
                HienThi();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (KiemTraNgoaiLeSua())
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = tbMaNV.Text;
                nv.HoTen = tbHoTen.Text;
                nv.Tuoi = int.Parse(tbTuoi.Text);
                nv.Luong = Convert.ToDouble(tbLuong.Text);
                nv.Xa = tbXa.Text;
                nv.Huyen = tbHuyen.Text;
                nv.Tinh = tbTinh.Text;
                nv.DienThoai = tbDienThoai.Text;
                dataUtil.Update(nv);
                HienThi();
            }
        }

        private void btnNVLuongTren1000_Click(object sender, EventArgs e)
        {
            nhanViens = dataUtil.Show();
            var query = from n in nhanViens where n.Luong > 1000 select n;
            lbNVLuongTren1000.Text = query.Count().ToString();
            dtgNhanVien.DataSource = query.ToList();
        }

        private void btnNVTrongTinh_Click(object sender, EventArgs e)
        {
            nhanViens = dataUtil.Show();
            var queryTinh = from n in nhanViens where n.Tinh.Equals(tbTinh.Text) select n;
            dtgNhanVien.DataSource = queryTinh.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            nhanViens = dataUtil.Show();
            var querySearch = from n in nhanViens where n.MaNV.Equals(tbMaNV.Text) select n;
            dtgNhanVien.DataSource = querySearch.ToList();
        }
    }
}
