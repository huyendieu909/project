using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoangXuanQuy_2021604440_proj91
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NhanVien> dsNhanVien = new List<NhanVien>()
            {
                new NhanVien() {HoTen = "A hihi", GioiTinh = "Nam", NgaySinh = new DateTime(2022,11,1), NgoaiNgu = "Anh", PhongBan = "Vật tư"}
            };
        public MainWindow()
        {
            InitializeComponent();
            dtgDSNhanVien.ItemsSource = dsNhanVien;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn kết thúc chương trình?", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window1 myWindow = new Window1();
            myWindow.Show();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.NgaySinh = (DateTime)dtpNgaySinh.SelectedDate;
            nhanVien.GioiTinh = (radNam.IsChecked == true) ? "Nam" : "Nữ";
            nhanVien.GioiTinh = "";
            if (cbAnh.IsChecked == true) { nhanVien.GioiTinh += "Anh"; }
            if (cbPhap.IsChecked == true) { nhanVien.GioiTinh += "Pháp"; }
            if (cbTrung.IsChecked == true) { nhanVien.GioiTinh += "Trung"; }
            nhanVien.PhongBan = "";
            dsNhanVien.Add(nhanVien);
            dtgDSNhanVien.ItemsSource = dsNhanVien;
        }
    }
}
