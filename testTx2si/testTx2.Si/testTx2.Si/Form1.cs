using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testTx2.Si
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<NhanVien> nhanViens = new List<NhanVien>();
        DataUtil dataUtil = new DataUtil();
        public void Show()
        {
            nhanViens = dataUtil.Show();
            dtgNhanVien.DataSource = nhanViens;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void dtgNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien nv = dtgNhanVien.CurrentRow.DataBoundItem as NhanVien;
            tbMaNV.Text = nv.MaNV;
            tbHoTen.Text = nv.HoTen;
            tbTuoi.Text = nv.Tuoi.ToString();
            tbLuong.Text = nv.Luong.ToString();
            tbXa.Text = nv.Xa;
            tbHuyen.Text = nv.Huyen;
            tbTinh.Text = nv.Tinh;
            tbDienThoai.Text = nv.DienThoai;
        }
        public bool KiemTraThem()
        {
            try
            {
                int tuoi = int.Parse(tbTuoi.Text);
            }
            catch
            {
                MessageBox.Show("Tuổi không phải số!");
                tbTuoi.Focus();
                return false;
            }
            try
            {
                double luong = Convert.ToDouble(tbLuong.Text);
            }
            catch
            {
                MessageBox.Show("Lương không phải số!");
                tbLuong.Focus();
                return false;
            }
            if (dataUtil.TrungMa(tbMaNV.Text))
            {
                return false;
            }
            return true;
        }
        public bool KiemTraCapNhat()
        {
            try
            {
                int tuoi = int.Parse(tbTuoi.Text);
            }
            catch
            {
                MessageBox.Show("Tuổi không phải số!");
                tbTuoi.Focus();
                return false;
            }
            try
            {
                double luong = Convert.ToDouble(tbLuong.Text);
            }
            catch
            {
                MessageBox.Show("Lương không phải số!");
                tbLuong.Focus();
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KiemTraThem())
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
                Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                dataUtil.Delete(tbMaNV.Text);
                Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (KiemTraCapNhat())
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
                Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = from n in nhanViens where n.Luong > 1000 select n;
            double tongLuong = 0;
            foreach (var n in query)
            {
                tongLuong += n.Luong;
            }
            dtgNhanVien.DataSource = query.ToList();
            lbTongLuongTren1000.Text = tongLuong.ToString();
        }

        private void btnTimNVTrong1Tinh_Click(object sender, EventArgs e)
        {
            var query = from n in nhanViens where n.Tinh == tbTinh.Text select n;
            dtgNhanVien.DataSource = query.ToList();
        }
    }
}
