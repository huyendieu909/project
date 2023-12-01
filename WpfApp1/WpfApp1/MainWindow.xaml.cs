using Microsoft.EntityFrameworkCore.Storage;
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
using WpfApp1.QLPhongBan;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ngayThanhLap.SelectedDate = DateTime.Now;
        }
        
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        QlphongBanContext db = new QlphongBanContext();
        public void HienThiDuLieu()
        {
            var queryPhongBan = from pb in db.PhongBans select pb;
            dtgPhongBan.ItemsSource = queryPhongBan.ToList();
        }
        public bool KiemTraNhapLieu()
        {
            if (tbMaPB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phòng ban!");
                return false;
            }
            if (tbTenPB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên phòng ban!");
                return false;
            }
            var queryMaPB = from pb in db.PhongBans where pb.MaPb == tbMaPB.Text select pb;
            if (queryMaPB.Count() > 0)
            {
                MessageBox.Show($"Mã phòng ban {tbMaPB.Text} đã tồn tại!");
                tbMaPB.SelectAll();
                tbMaPB.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTraNhapLieu())
            {
                PhongBan pbNew = new PhongBan();
                pbNew.MaPb = tbMaPB.Text;
                pbNew.TenPb = tbTenPB.Text;
                pbNew.NgayThanhLap = ngayThanhLap.SelectedDate.ToString();
                db.PhongBans.Add(pbNew);
                db.SaveChanges();
            }
            HienThiDuLieu();
        }
    }
}