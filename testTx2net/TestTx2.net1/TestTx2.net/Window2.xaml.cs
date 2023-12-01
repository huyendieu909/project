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
using System.Windows.Shapes;

namespace TestTx2.net
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        internal Window2(List<NhanVien> nv)
        {
            InitializeComponent();
            int maxt = nv[0].Tuoi;
            nv.ForEach(n => { if (maxt < n.Tuoi) maxt = n.Tuoi; });
            var query = from n in nv where n.Tuoi == maxt select n;
            dtgNhanVien2.ItemsSource = query.ToList();
        }
        private void dtgNhanVien2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
