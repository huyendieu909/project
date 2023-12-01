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

namespace Bai93
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string gt = "", tthn = "", st = "";
            if (radNam.IsChecked == true) { gt = "nam"; }
            else { gt = "nữ"; } 

            if (radDaKetHon.IsChecked == true) { tthn = "Đã kết hôn"; }
            else { tthn = "Chưa kết hôn"; }

            if (chkBongDa.IsChecked == true) st += "Đá bóng, ";
            if (chkBoiLoi.IsChecked == true) st += "Bơi lội, ";
            if (chkLeoNui.IsChecked == true) st += "Leo núi, ";
            if (chkAmNhac.IsChecked == true) st += "Âm nhạc";
            lstHienThi.Items.Add("Họ tên: " + txtHoTen.Text);
            lstHienThi.Items.Add("Giới tính: " + gt);
            lstHienThi.Items.Add("Tình trạng hôn nhân: "+ tthn);
            lstHienThi.Items.Add("Sở thích: " + st);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
