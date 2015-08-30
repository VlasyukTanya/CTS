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
//using WpfControlLibrary1;
using System.Windows.Markup;
using WPFCTSTuterModule.ServiceReference1;
using System.Data;

namespace WPFCTSTuterModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.ServiceCTSClient proxy = new ServiceReference1.ServiceCTSClient();
        //for combobox to use in another events
        List<string> listOfNames = new List<string>();
        public static int idOfStudent;
        public static string nameOfStudent;

        public MainWindow()
        {
            InitializeComponent();
            nameOfStudent = "";
            idOfStudent = -1;
            //ServiceCTSClient proxy = new ServiceCTSClient();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
            lvSubjects.ItemsSource = dt.DefaultView;

        }

        public void TestManageTabClick(Object sender, MouseEventArgs e)
        {
            //TAB CLICK EVENT!
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //QUESTION.cl
        }

        private void SubjectsViewClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                DataRowView row = item as DataRowView;
                DataTable dt = proxy.GetTestsDataTableBySubjectId(Convert.ToInt32(row["id"]));
                lvTests.ItemsSource = dt.DefaultView;
            }
            //proxy.GetTestsDataTableBySubjectId();
        }

        private void TestsViewClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                DataRowView row = item as DataRowView;
                DataTable dt = proxy.GetQuestionsDataTableByTestId(Convert.ToInt32(row["id"]));
                //MessageBox.Show(dt.Rows.Count.ToString());
                DataGridQuestions.ItemsSource = dt.DefaultView;
            }
        }

        private void DataGridQuestionsClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row != null)
            {
                DataRowView drv = row.Item as DataRowView;
                DataTable dt = proxy.GetAnswersDataTableByQuestionId(Convert.ToInt32(drv["id"]));
                DataGridAnswers.DataContext = dt.DefaultView;
            }
        }
        // для нумерации строк
        private void AnswerDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        // show question as it should to be
        private void QuestionShowButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)DataGridQuestions.SelectedItem;
            if (drv != null)
            {
                //DataRowView drv = row.Item as DataRowView;
                string s = proxy.DrawQuestionById(Convert.ToInt32(drv["id"]));
                //MessageBox.Show(s);
                WindowQuestionView winQ = new WindowQuestionView(s);
                winQ.Show();
                //this.Close();
            }
        }

        private void AnswerDataGrid_Click(object sender, MouseButtonEventArgs e)
        {
            //
        }

        //select user, added by Lesya
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = selectUser_combo.SelectedIndex;
            if (ind > -1)
            {
                nameOfStudent = selectUser_combo.SelectedItem.ToString();
                DataTable dt = proxy.GetUsersDataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (nameOfStudent == dt.Rows[i]["real_name"].ToString())
                        idOfStudent = Convert.ToInt32(dt.Rows[i]["id"]);
                }
            }
            else
            {
                nameOfStudent = "";
            }
        }

        //fill combobox, added by Lesya
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (backgroundcolor.IsSelected)
                { 
                    DataTable dt = proxy.GetUsersDataTable();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        selectUser_combo.Items.Add(dt.Rows[i]["real_name"].ToString());
                        listOfNames.Add(dt.Rows[i]["real_name"].ToString());
                    }
                }
            }
        }

        private void AppointTest_Click(object sender, RoutedEventArgs e)
        {
            if (nameOfStudent=="")
            { 
                MessageBox.Show("Выберите студента!"); 
            }
            else
            {
                try
                {
                    Window1 Appoint = new Window1(idOfStudent, nameOfStudent);
                    Appoint.ShowDialog();

                }

                catch (Exception err)
                { MessageBox.Show(err.Message); }
            }

        }


    }


}
