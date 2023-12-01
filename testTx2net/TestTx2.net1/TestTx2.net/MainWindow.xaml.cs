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

namespace TestTx2.net
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
        static List<NhanVien> nv = new List<NhanVien>();
        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTra())
            {
                NhanVien nvm = new NhanVien();
                nvm.MaNV = tbMaNV.Text;
                nvm.HoTen = tbHoTen.Text;
                nvm.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
                nvm.GioiTinh = (radNam.IsChecked == true) ? "Nam" : "Nữ";
                nvm.PhongBan = (cbiToChuc.IsSelected == true) ? "Tổ chức" : (cbiKeHoach.IsSelected == true) ? "Kế hoạch" : "Vật tư";  
                //nvm.PhongBan = cbPhongBan.SelectedItem.ToString();
                nvm.HeSoLuong = Convert.ToDouble(tbHeSoLuong.Text);
                nv.Add(nvm);
                
            }
            HienThi();
        }

        public void HienThi()
        {
            var query = from n in nv select n;
            dtgNhanVien.ItemsSource = query.ToList();
        }
        public bool KiemTra()
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
            if (Convert.ToDouble(tbHeSoLuong.Text) < 0)
            {
                MessageBox.Show("Hệ số lương phải lớn hơn 0!");
                return false;
            }
            if ((int) (DateTime.Now - dtpNgaySinh.SelectedDate).Value.TotalDays / 365 < 18)
            {
                MessageBox.Show("Tuổi của nhân viên phải lớn hơn 18");
                return false;   
            } 
            return true;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(nv);
            window2.Show();
        }
    }
}