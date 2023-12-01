using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testTx2net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dtpNgaySinh.SelectedDate = DateTime.Now;
        }

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTraNhap())
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNV = tbMaNV.Text;    
                nhanVien.HoTen = tbHoTen.Text;
                nhanVien.NgaySinh = dtpNgaySinh.SelectedDate;
                nhanVien.GioiTinh = (radNam.IsChecked == true) ? "Nam" : "Nữ";
                nhanVien.PhongBan = cbPhongBan.SelectedItem.ToString();
                nhanVien.HeSoLuong = Convert.ToDouble(tbHeSoLuong.Text);
                nhanViens.Add(nhanVien);
                HienThiThongTin();
            }
        }
        static List<NhanVien> nhanViens = new List<NhanVien>();
        public void HienThiThongTin ()
        {
            var query = from nhanVien in nhanViens select nhanVien;
            dtgNhanVien.ItemsSource = query.ToList();
        }
        public bool KiemTraNhap()
        {
            if (tbMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!");
                return false;
            }
            if (tbHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên!");
                return false;
            }
            if ( (int)(DateTime.Now - dtpNgaySinh.SelectedDate).Value.TotalDays / 365 < 18)
            {
                MessageBox.Show("Tuổi nhân viên phải >= 18!");
                return false;
            }
            if (tbHeSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập hệ số lương!");
                return false;   
            }
            if (Convert.ToDouble(tbHeSoLuong.Text) <= 0)
            {
                MessageBox.Show("Hệ số lương phải > 0!");
                return false;
            }
            return true;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2 (nhanViens);
            window.Show();
        }

        private void dtgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhanVien nv = dtgNhanVien.SelectedItem as NhanVien;
            if (nv != null)
            {
                tbMaNV.Text = nv.MaNV;
                tbHoTen.Text = nv.HoTen;
                dtpNgaySinh.SelectedDate = nv.NgaySinh;
                if (nv.GioiTinh == "Nam") radNam.IsChecked = true;
                else radNu.IsChecked = true;
                cbPhongBan.Text = nv.PhongBan;
                tbHeSoLuong.Text = nv.HeSoLuong.ToString();
            }
        }
    }
}