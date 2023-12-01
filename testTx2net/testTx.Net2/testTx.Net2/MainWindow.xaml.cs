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

namespace testTx.Net2
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
                nv.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
                nv.GioiTinh = (radNam.IsChecked == true) ? "Nam" : "Nữ";
                nv.PhongBan = cbPhongBan.Text;
                nv.HeSoLuong = Convert.ToDouble(tbHeSoLuong.Text);
                nhanViens.Add(nv);
            }
            HienThi();
        }


        public bool KiemTra()
        {
            int trungMa = 0;
            nhanViens.ForEach(n => { if (n.MaNV.Equals(tbMaNV.Text)) trungMa++; });
            if (trungMa != 0)
            {
                MessageBox.Show($"Mã nhân viên {tbMaNV.Text} đã tồn tại!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (tbMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (tbHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên nhân viên!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            try
            {
                double luong = double.Parse(tbHeSoLuong.Text);
                if (luong < 0)
                {
                    MessageBox.Show("Hệ số lương phải > 0!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    tbHeSoLuong.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số thực!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbHeSoLuong.Focus();
                return false;
            }
            DateTime ns =(DateTime) dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Tuổi của nhân viên phải >= 18!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            } 
            return true;
        }
      
        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            int tuoiMax = nhanViens[0].Tuoi;
            nhanViens.ForEach(n => { if (n.Tuoi > tuoiMax) tuoiMax = n.Tuoi; });
            List<NhanVien> nvLonTuoi = new List<NhanVien>();
            nhanViens.ForEach(n => { if (n.Tuoi == tuoiMax) nvLonTuoi.Add(n); });
            var queryLonTuoi = from n in nvLonTuoi select n;
            Window2 window2 = new Window2();
            window2.dtgNVLonTuoi.ItemsSource = queryLonTuoi.ToList();
            window2.Show();
        }
    }
}