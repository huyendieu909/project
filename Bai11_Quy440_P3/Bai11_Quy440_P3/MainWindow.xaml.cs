using Bai11_Quy440_P3.QLBanHang;
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

namespace Bai11_Quy440_P3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HienThiThongTin();
        }
        QlbanHangContext db = new QlbanHangContext();
        public void HienThiThongTin()
        {
            var queryShow = from sp in db.SanPhams select sp;
            dtgSanPham.ItemsSource = queryShow.ToList();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Environment.Exit(0);
            }
        }
        public bool KiemTraThongTinNhap()
        {
            if (tbMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm!");
                return false;
            }
            if (tbTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm!");
                return false;
            }
            if (tbSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!");
                return false;
            }
            if (tbDonGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!");
                return false;
            }
            if (tbMaLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại!");
                return false;
            }
            var queryTimMaSP = from sp in db.SanPhams where tbMaSP.Text == sp.MaSp select sp;
            if (queryTimMaSP.Count() > 0)
            {
                MessageBox.Show($"Mã sản phẩm {tbMaSP.Text} đã tồn tại trong danh sách!");
                tbMaSP.SelectAll();
                tbMaSP.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTraThongTinNhap())
            {
                SanPham sp = new SanPham();
                sp.MaSp = tbMaSP.Text;
                sp.TenSp = tbTenSP.Text;
                sp.SoLuong = Convert.ToInt32(tbSoLuong.Text);
                sp.DonGia = Convert.ToInt32(tbDonGia.Text);
                sp.MaLoai = tbMaLoai.Text;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                HienThiThongTin();
                ClearAllTextBox();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var spXoa = db.SanPhams.SingleOrDefault(c => c.MaSp == tbMaSP.Text);
            if (spXoa == null)
            {
                MessageBox.Show($"Sản phẩm mã {tbMaSP.Text} không tồn tại trong danh sách!");
            }
            else
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa?", "Delete Notify", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    db.SanPhams.Remove(spXoa);
                    db.SaveChanges();
                    HienThiThongTin();
                }

            }
        }

        private void dtgSanPham_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            SanPham sp = dtgSanPham.CurrentItem as SanPham;
            if (sp != null)
            {
                tbMaSP.Text = sp.MaSp.ToString();
                tbTenSP.Text = sp.TenSp.ToString();
                tbSoLuong.Text = sp.SoLuong.ToString();
                tbDonGia.Text = sp?.DonGia.ToString();
                tbMaLoai.Text = sp.MaLoai.ToString();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var querySua = db.SanPhams.SingleOrDefault(x => x.MaSp == tbMaSP.Text);
            if (querySua != null)
            {
                querySua.TenSp = tbTenSP.Text;
                querySua.SoLuong = Convert.ToInt32(tbSoLuong.Text);
                querySua.DonGia = Convert.ToInt32(tbDonGia.Text);
                querySua.MaLoai = tbMaLoai.Text;
                db.SaveChanges();
                HienThiThongTin();
            }
        }
        public void ClearAllTextBox()
        {
            tbMaSP.Clear();
            tbTenSP.Clear();
            tbSoLuong.Clear();
            tbDonGia.Clear();
            tbMaLoai.Clear();
        }
    }
}