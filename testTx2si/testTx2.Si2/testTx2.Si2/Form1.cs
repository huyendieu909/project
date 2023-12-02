using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testTx2.Si2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nhanViens = dataUtil.Show();
            var queryTim = from n in nhanViens where n.MaNV.Equals(tbMaNV.Text) select n;
            dtgNhanVien.DataSource = queryTim.ToList();
        }
        DataUtil dataUtil = new DataUtil();
        List<NhanVien> nhanViens = new List<NhanVien>();
        private void btnShow_Click(object sender, EventArgs e)
        {
            HienThi();
            double sum = 0;
            int sl = 0;
            nhanViens.ForEach(n => { if (n.Luong > 1000) sum += n.Luong; sl++; });
            lbSLNVLuongTren1000.Text = sl.ToString();
            lbTongLuongTren1000.Text = sum.ToString();
        }
        public void HienThi()
        {
            nhanViens = dataUtil.Show();
            dtgNhanVien.DataSource = nhanViens;
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
                HienThi();
            }
        }
        public bool KiemTraThem()
        {
            if (dataUtil.MaNVDaTonTai(tbMaNV.Text))
            {
                MessageBox.Show($"Mã nhân viên {tbMaNV.Text} đã tồn tại trong danh sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        public bool KiemTraSua()
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                dataUtil.Delete(tbMaNV.Text);
                HienThi();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (KiemTraSua())
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

        private void btnNVTheoTinh_Click(object sender, EventArgs e)
        {
            if (tbTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tỉnh!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbTinh.Focus();
            }
            else
            {
                nhanViens = dataUtil.Show();
                var queryTinh = from n in nhanViens where n.Tinh.Equals(tbTinh.Text) select n;
                if (queryTinh.Count() == 0)
                {
                    MessageBox.Show($"Không có nhân viên nào trong tỉnh {tbTinh.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbTinh.Focus();
                }
                else
                {
                    dtgNhanVien.DataSource = queryTinh.ToList();
                }

            }


        }
    }
}
