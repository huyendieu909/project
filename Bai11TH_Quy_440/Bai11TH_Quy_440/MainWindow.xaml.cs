using Bai11TH_Quy_440.QLNhanSu;
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

namespace Bai11TH_Quy_440
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
            HienThi();
        }
        public void HienThi()
        {
            QlnhanSuContext db = new QlnhanSuContext();
            var queryShowAll = from ns in db.NhanViens select ns;
            dtgNhanVien.ItemsSource = queryShowAll.ToList();
        }

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            QlnhanSuContext db = new QlnhanSuContext();
            if (KiemTraNgoaiLeThem())
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = tbMaNV.Text;
                nv.HoTen = tbHoTen.Text;
                nv.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
                nv.Gioitinh = (radNam.IsChecked == true)? "Nam" : "Nữ";
                nv.NgoaiNgu = " ";
                if (ckbTiengAnh.IsChecked == true)
                {
                    nv.NgoaiNgu += "Anh,";
                }
                if (ckbTiengTrung.IsChecked == true)
                {
                    nv.NgoaiNgu += "Trung,";
                }
                if (cknTiengNga.IsChecked == true)
                {
                    nv.NgoaiNgu += "Nga ";
                }
                nv.NgoaiNgu = nv.NgoaiNgu.Substring(0, nv.NgoaiNgu.Length - 1);
                nv.MaPb = tbMaPB.Text;
                db.NhanViens.Add(nv);
                db.SaveChanges();
                HienThi();
            }
        }

        private void dtgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhanVien nv = dtgNhanVien.CurrentItem as NhanVien;
            if (nv != null)
            {
                tbMaNV.Text = nv.MaNv;
                tbHoTen.Text = nv.HoTen;
                dtpNgaySinh.SelectedDate = nv.NgaySinh;
                if (nv.Gioitinh.Equals("nam")) radNam.IsChecked = true;
                else radNu.IsChecked = true;
                tbMaPB.Text = nv.MaPb;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            QlnhanSuContext db = new QlnhanSuContext();
            NhanVien nv = new NhanVien();
            var queryXoa = from n in db.NhanViens where n.MaNv.Equals(tbMaNV.Text) select n;
            foreach ( var n in queryXoa )
            {
                nv = n; break;
            }
            if (queryXoa.Count() > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    db.Remove(nv);
                    db.SaveChanges();
                    HienThi();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xóa!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.Focus();
            }

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTraNgoaiLeSua())
            {
                QlnhanSuContext db = new QlnhanSuContext();
                var querySua = from n in db.NhanViens where n.MaNv.Equals(tbMaNV.Text) select n;
                NhanVien nv = querySua.FirstOrDefault();
                if (nv != null)
                {
                    nv.MaNv = tbMaNV.Text;
                    nv.HoTen = tbHoTen.Text;
                    nv.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
                    nv.Gioitinh = (radNam.IsChecked == true)? "Nam" : "Nữ";
                    nv.NgoaiNgu = " ";
                    if (ckbTiengAnh.IsChecked == true)
                    {
                        nv.NgoaiNgu += "Anh,";
                    }
                    if (ckbTiengTrung.IsChecked == true)
                    {
                        nv.NgoaiNgu += "Trung,";
                    }
                    if (cknTiengNga.IsChecked == true)
                    {
                        nv.NgoaiNgu += "Nga ";
                    }
                    nv.NgoaiNgu = nv.NgoaiNgu.Substring(0, nv.NgoaiNgu.Length - 1);
                    nv.MaPb = tbMaPB.Text;
                    db.SaveChanges();
                    HienThi();
                } else
                {
                    MessageBox.Show("Nhân viên có mã trên không tồn tại!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    tbMaNV.Focus();
                }
            }
        }

        public bool KiemTraNgoaiLeThem()
        {
            QlnhanSuContext db = new QlnhanSuContext();
            var query = from n in db.NhanViens where n.MaNv.Equals(tbMaNV.Text) select n;
            if (query.Count() > 0)
            {
                MessageBox.Show($"Mã nhân viên {tbMaNV.Text} đã tồn tại!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaNV.SelectAll();
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
            if (tbMaPB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phòng ban!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaPB.Focus();
                return false;
            }
            DateTime ns = (DateTime)dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Nhân viên phải >= 18 tuổi!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }

        public bool KiemTraNgoaiLeSua()
        {
            QlnhanSuContext db = new QlnhanSuContext();
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
            if (tbMaPB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phòng ban!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbMaPB.Focus();
                return false;
            }
            DateTime ns = (DateTime)dtpNgaySinh.SelectedDate;
            if (DateTime.Now.Year - ns.Year < 18)
            {
                MessageBox.Show("Nhân viên phải >= 18 tuổi!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }
    }
}