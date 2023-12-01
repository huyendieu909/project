using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testTx2si
{
    public partial class tx2 : Form
    {
        public tx2()
        {
            InitializeComponent();
        }
        DataUtil dataUtil = new DataUtil();
        List<NhanVien> nhanViens = new List<NhanVien>();
        private void tx2_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {
            nhanViens = dataUtil.Show();
            dtgNhanVien.DataSource = nhanViens;
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = tbMaNV.Text;
            nv.HoTen = tbHoTen.Text;
            nv.Tuoi = Convert.ToInt32(tbTuoi.Text);
            nv.Luong = Convert.ToDouble(tbLuong.Text);
            nv.Xa = tbXa.Text;
            nv.Huyen = tbHuyen.Text;
            nv.Tinh = tbTinh.Text;
            nv.SoDienThoai = tbDienThoai.Text;
            if (dataUtil.checkMaNV(nv.MaNV))
            {
                dataUtil.Add(nv);
                HienThi();
            }
            else
            {
                MessageBox.Show($"Đã tồn tại nhân viên có mã {nv.MaNV} trong danh sách");
            }
        }

        private void dtgNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien nv = dtgNhanVien.CurrentRow.DataBoundItem as NhanVien;
            tbMaNV.Text = nv.MaNV.ToString();
            tbHoTen.Text = nv.HoTen.ToString();
            tbTuoi.Text = nv.Tuoi.ToString();
            tbLuong.Text = nv.Luong.ToString();
            tbXa.Text = nv.Xa.ToString();
            tbHuyen.Text = nv.Huyen.ToString();
            tbTinh.Text = nv.Tinh.ToString();
            tbDienThoai.Text = nv.SoDienThoai.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataUtil.Delete(tbMaNV.Text);
            HienThi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = tbMaNV.Text;
            nv.HoTen = tbHoTen.Text;
            nv.Tuoi = Convert.ToInt32(tbTuoi.Text); 
            nv.Luong = Convert.ToDouble(tbLuong.Text);
            nv.Xa = tbXa.Text;
            nv.Huyen = tbHuyen.Text;
            nv.Tinh = tbTinh.Text;
            nv.SoDienThoai = tbDienThoai.Text;
            dataUtil.Update(nv);
            HienThi();
        }
    }
}
