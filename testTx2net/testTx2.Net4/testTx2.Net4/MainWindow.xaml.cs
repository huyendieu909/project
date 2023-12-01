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

namespace testTx2.Net4
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
                nv.HeSoLuong = double.Parse(tbHeSoLuong.Text);
                nhanViens.Add(nv);
            }
            HienThi();
        }
        public void HienThi()
        {
            var query = from n in nhanViens select n;
            dtgNhanVien.ItemsSource = query.ToList();
        }
        public bool KiemTra()
        {
            int trungMa = 0;
            nhanViens.ForEach(n => { if (n.MaNV.Equals(tbMaNV.Text)) trungMa++; });
            if (trungMa != 0)
            {
                MessageBox.Show($"Mã nhân viên {tbMaNV.Text} đã tồn tại trong danh sách!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
                return false;
            }
            if (tbMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
                return false;
            }
            if (tbHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbHoTen.Focus();
                return false;
            }
            if (tbHeSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập hệ số lương!");
            }
            try
            {
                double luong = Convert.ToDouble(tbHeSoLuong.Text);
                if (luong < 0)
                {
                    MessageBox.Show("Hệ số lương phải là số thực > 0!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    tbHeSoLuong.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số thực!");
                tbHeSoLuong.Focus();
                return false;
            }
            DateTime ns = (DateTime)dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Tuổi của nhân viên phải >= 18!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            int maxTuoi = nhanViens[0].Tuoi;
            nhanViens.ForEach(n => { if (n.Tuoi > maxTuoi) { maxTuoi = n.Tuoi; } });
            List<NhanVien> nvLonTuoi = new List<NhanVien>();
            nhanViens.ForEach(n => { if (n.Tuoi == maxTuoi) nvLonTuoi.Add(n); });
            var queryLonTuoi = from n in nvLonTuoi select n;
            Window2 window2 = new Window2();
            window2.dtgNVLonTuoi.ItemsSource = queryLonTuoi.ToList();
            window2.Show();
        }

        private void dtgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhanVien? nv = dtgNhanVien.CurrentItem as NhanVien;
            if (nv != null)
            {
                tbMaNV.Text = nv.MaNV;
                tbHoTen.Text = nv.HoTen;
                dtpNgaySinh.SelectedDate = nv.NgaySinh;
                if (nv.GioiTinh.Equals("Nam")) radNam.IsChecked = true;
                else radNu.IsChecked = true;
                cbPhongBan.Text = nv.PhongBan;
                tbHeSoLuong.Text = nv.HeSoLuong.ToString();
            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            int tt = 0;
            nhanViens.ForEach(x => { if (x.MaNV.Equals(tbMaNV.Text)) tt++; });
            if (tbMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
            }
            else if (tt == 0)
            {
                MessageBox.Show($"Không tồn tại mã nhân viên {tbMaNV.Text} trong danh sách !", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    nhanViens.RemoveAll(n => n.MaNV.Equals(tbMaNV.Text));
                    HienThi();
                }
            }
        }

        public bool KiemTraSua()
        {
            if (tbHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbHoTen.Focus();
                return false;
            }
            if (tbHeSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập hệ số lương!");
            }
            try
            {
                double luong = Convert.ToDouble(tbHeSoLuong.Text);
                if (luong < 0)
                {
                    MessageBox.Show("Hệ số lương phải là số thực > 0!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    tbHeSoLuong.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số thực!");
                tbHeSoLuong.Focus();
                return false;
            }
            DateTime ns = (DateTime)dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Tuổi của nhân viên phải >= 18!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            int tt = 0;
            nhanViens.ForEach(x => { if (x.MaNV.Equals(tbMaNV.Text)) tt++; });
            if (tbMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần sửa!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
            }
            else if (tt == 0)
            {
                MessageBox.Show($"Không tồn tại mã nhân viên {tbMaNV.Text} trong danh sách !", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
            }
            else
            {
                if (KiemTraSua())
                {
                    foreach (NhanVien n in  nhanViens)
                    {
                        if (n.MaNV.Equals(tbMaNV.Text))
                        {
                            n.MaNV = tbMaNV.Text;
                            n.HoTen = tbHoTen.Text;
                            n.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
                            n.GioiTinh = (radNam.IsChecked == true)? "Nam" : "Nữ";
                            n.PhongBan = cbPhongBan.Text;
                            n.HeSoLuong = Convert.ToDouble(tbHeSoLuong.Text);
                            HienThi();
                        }
                    }
                }
            }
        }
    }
}