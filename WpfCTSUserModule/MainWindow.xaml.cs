﻿using System;
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

namespace WpfCTSUserModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private string userName;
        private TestWindow parent;

        public MainWindow(TestWindow parent)
        {
            this.parent = parent;
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
            this.parent.Show();
            this.Close();
        }
    }
}
