using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace ServerModule
{
    public partial class Form1 : Form
    {
        ServiceHost sh;
        public Form1()
        {
            InitializeComponent();
             sh = new ServiceHost(typeof(ServiceCTS));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sh.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sh.Close();
        }
    }
}
