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
using WPFCTSTuterModule.ServiceReference1;
using System.Data;

namespace WPFCTSTuterModule
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceReference1.ServiceCTSClient proxy = new ServiceReference1.ServiceCTSClient();
        //user id
        public int id;
        //name of user
        public string nameOfStudent;

        public Window1(int i, string str)

        {
            InitializeComponent();
            id = i;
            nameOfStudent = str;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            col1.Content = "Id: " + id;
            col2.Content = "Имя: " + nameOfStudent;

            DataTable dt = new DataTable();
            try
            {
                dt = proxy.GetSubjectsDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showSubj.ItemsSource = dt.DefaultView;
        }

        private void button_appoint_Click(object sender, RoutedEventArgs e)
        {
            if ((showTest.SelectedIndex>-1)&&(numOfTries.SelectedIndex>-1)&&((tb_hours.Text!="00")||(tb_min.Text!="00")))
            {
                if (dp.SelectedDate == null)
                
                    dp.SelectedDate = DateTime.Today;


                DataRowView drv = (DataRowView)showTest.SelectedItem;
                //test id
                int t_id = Convert.ToInt32(drv["id"]);

                //                    string subject = drv["Name"].ToString();

                //cut only date, not time
                string time_temp = dp.SelectedDate.ToString().Substring(0, 11);

                //if DateTime is needed. Add time to date

                int h = Convert.ToInt32(combo_hours.SelectedValue);
                int m = Convert.ToInt32(combo_min.SelectedValue);
                TimeSpan ts = new TimeSpan(h, m, 0);
                DateTime mySelectedDateTime = Convert.ToDateTime(time_temp) + ts;


                //if string is needed.
                //                    MessageBox.Show(mySelectedDateTime.ToString("yyyy/MM/dd hh:mm:ss"));

                //available time in sec
                int avail = ((Convert.ToInt32(tb_hours.Text) * 60) + Convert.ToInt32(tb_min.Text)) * 60;

                int tries = Convert.ToInt32(numOfTries.SelectedValue);

                try
                {
                    proxy.addUserTest(id, t_id, tries, -1f, true, mySelectedDateTime, true, true, avail);
                }

                catch (Exception err)
                {MessageBox.Show(err.Message);}

                MessageBoxResult res = MessageBox.Show("Тест назначен! Назначить ещё тест для этого пользователя?", "Notation", MessageBoxButton.YesNo);
                
                if (res==MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    showSubj.SelectedIndex=-1;
                    showTest.SelectedIndex = -1;
                    numOfTries.SelectedIndex = -1;
                    tb_hours.Text = "00";
                    tb_min.Text = "00";
                }
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void showSubj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                DataRowView row = item as DataRowView;
                DataTable dt = proxy.GetTestsDataTableBySubjectId(Convert.ToInt32(row["id"]));
                showTest.ItemsSource = dt.DefaultView;
            }
        }


    }
}
