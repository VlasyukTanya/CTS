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

namespace WpfCTSAdminModule
{
    /// <summary>
    /// Interaction logic for WindowTutor.xaml
    /// </summary>
    public partial class WindowTutor : Window
    {
        public WindowTutor()
        {
            InitializeComponent();
        }

        public WindowTutor(string fio, string login, string email, string skype, string telephon, string group)
        {
            this.tRealName.Text = fio;
            this.tLogin.Text = login;
            this.tEmail.Text = email;
            this.tSkype.Text = skype;
            this.tTeleph.Text = telephon;
            this.tGroup.Text = group;
        }

        public string Fio
        {
            get { return tRealName.Text; }
            set { tRealName.Text = value; }
        }

        public string Login
        {
            get { return tLogin.Text; }
            set { tLogin.Text = value; }
        }
        public string Email
        {
            get { return tEmail.Text; }
            set { tEmail.Text = value; }
        }
        public string Skype
        {
            get { return tSkype.Text; }
            set { tSkype.Text = value; }
        }

        public string Telephon
        {
            get { return tTeleph.Text; }
            set { tTeleph.Text = value; }
        }

        public string Group
        {
            get { return tGroup.Text; }
            set { tGroup.Text = value; }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (this.tRealName.Text == "" || this.tLogin.Text == "" || this.tEmail.Text == "")
                MessageBox.Show("Не заполнены обязательные поля: ФИО,Login, Email!!!");
            else
                DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
