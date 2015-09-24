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
using System.Windows.Markup;
using WpfCTSUserModule.ServiceReference1;
using System.Data;

namespace WpfCTSUserModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        ServiceReference1.ServiceCTSClient proxy = new ServiceReference1.ServiceCTSClient();
        private string userName;

        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.Show();
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public void RegUser()
        {
            this.userNameLabel.Content += this.userName;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TestWindow tw = new TestWindow(this);
            tw.Show();
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = proxy.GetSubjectsDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(dt.Rows[0]["name"].ToString());
            /*foreach (string a in dt.DefaultView)
            {
                dt.
                testslist.ItemsSource = dt.Rows[0]["name"].ToString();
            }*/
            //MessageBox.Show(dt.DefaultView.ToString());
            testslist.ItemsSource = dt.DefaultView;
        }
    }
}
