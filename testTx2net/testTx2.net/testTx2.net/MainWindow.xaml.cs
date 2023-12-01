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

namespace testTx2.net
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
        List<NhanVien> nhanViens = new List<NhanVien>();
        public void HienThi ()
        {
            var query = from n in nhanViens select n;
            dtgNhanVien.ItemsSource = query.ToList();
        }
        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTra())
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = tbMaNV.Text;
                nv.HoTen = tbHoTen.Text;
                nv.NgaySinh = (DateTime) dtpNgaySinh.SelectedDate;
                nv.GioiTinh = (radNam.IsChecked == true)? "Nam" : "Nữ";
                nv.PhongBan = cbPhongBan.Text;
                nv.HeSoLuong = double.Parse(tbHeSoLuong.Text);
                nhanViens.Add(nv);  
            }
            HienThi();
        }
        public bool KiemTra ()
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
            if (tbHeSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập hệ số lương!");
                return false;
            }
            try
            {
                double luong = Convert.ToDouble(tbHeSoLuong.Text);
                if (luong < 0)
                {
                    MessageBox.Show("Hệ số lương phải là số thực > 0!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số!");
                return false;
            }
            DateTime ns = (DateTime) dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Nhân viên phải lớn hơn 18 tuổi!");
                return false;
            }
            return true;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            int tuoiMax = nhanViens[0].Tuoi;
            nhanViens.ForEach(n => { if (n.Tuoi > tuoiMax) tuoiMax = n.Tuoi; });
            List<NhanVien> NVLonTuoi = new List<NhanVien>();    
            nhanViens.ForEach (n => { if (n.Tuoi == tuoiMax) NVLonTuoi.Add(n); });
            var query = from n in NVLonTuoi select n;
            Window2 window2 = new Window2();
            window2.dtgTuoiLonNhat.ItemsSource = query.ToList();
            window2.Show();
        }
    }
}