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

namespace Bai91
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstSach.Items.Add("Công nghệ thực tại ảo");
            lstSach.Items.Add("Đảm bảo chất lượng phần mềm");
            lstSach.Items.Add("Giải thuật di truyền và ứng dụng");
            lstSach.Items.Add("Hệ chuyên gia");
            lstSach.Items.Add("Lập trình căn bản");
            lstSach.Items.Add("Lập trình hướng đối tượng");
            lstSach.Items.Add("Lập trình mạng");
            lstSach.Items.Add("Lập trình trên Windows");
            lstSach.Items.Add("Một số phương pháp tính toán mềm");
            lstSach.Items.Add("Nhập môn tin học");
            lstSach.Items.Add("Phân tích thiết kế hệ thống");
            lstSach.Items.Add("Phân tích và thông kê số liệu");
            lstSach.Items.Add("Thiết kế cơ sở dữ liệu");
            lstSach.Items.Add("Thiết kế trang web");
            lstSach.Items.Add("Tin văn phòng");
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            lstChon.Items.Add(lstSach.SelectedItem);
            lstSach.Items.Remove(lstSach.SelectedItem);
        }

        private void btnThemHet_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstSach.Items)
            {
                lstChon.Items.Add(item);
            }
            lstSach.Items.Clear();
        }

        private void btnBo_Click(object sender, RoutedEventArgs e)
        {
            lstSach.Items.Add(lstChon.SelectedItem);
            lstChon.Items.Remove(lstChon.SelectedItem);
        }

        private void btnBoHet_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in lstChon.Items)
            {
                lstSach.Items.Add(item);
            }
            lstChon.Items.Clear();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
