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
using WpfCTSUserModule.ServiceCTS;

namespace WpfCTSUserModule
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow parent;
        public LoginWindow(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            using(ServiceCTSClient proxy = new ServiceCTSClient())
            {
                if (proxy.AuthenticateUser(this.loginTextBox.Text, this.passwordTextBox.Text))
                {
                    this.parent.UserName = this.loginTextBox.Text;
                    this.parent.RegUser();
                    this.parent.Show();
                    this.Close();
                }
                else
                {
                    this.statusLabel.Content = "Login Error";
                    this.statusLabel.Background = Brushes.Red;
                }
            }
        }
    }
}
