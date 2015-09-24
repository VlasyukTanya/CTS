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
using System.Windows.Markup;
using WpfCTSUserModule.ServiceReference1;
using System.Data;

namespace WpfCTSUserModule
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        ServiceReference1.ServiceCTSClient proxy = new ServiceReference1.ServiceCTSClient();
        private MainWindow parent;
        public TestWindow(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            
            //winQ.Show();
        }
    }
}
