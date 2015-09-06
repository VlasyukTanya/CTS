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
using System.Data;

using DBLibrary;
using WpfCTSAdminModule.ServiceReferenceCTS;

namespace WpfCTSAdminModule
{
    public class TestSubjects
    {
        public int Id {get; set; }
        public string Name { get; set; }
    }


    public partial class MainWindow : Window
    {
        ServiceReferenceCTS.ServiceCTSClient proxy = new ServiceReferenceCTS.ServiceCTSClient();

        public MainWindow()
        {
            InitializeComponent();
            //tabcontrol1.SelectedIndex = 2;
            LoadSubjects();
            LoadGroups();
            LoadTutors();
        }


        private void LoadSubjects()
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
            tabItem1ListView.ItemsSource = dt.DefaultView;
        }

        private void LoadTutors()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = proxy.GetTutorsDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tabItem2ListView.ItemsSource = dt.DefaultView;
        }

        private void LoadGroups()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = proxy.GetGroupsDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tabItem3ListView.ItemsSource = dt.DefaultView;
        }


        private void tabItem1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MethodAddSubjects();
        }

        private void tabItem1ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            MethodEditSubjects();
        }

        private void tabItem1ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MethodDeleteSubjects();
        }

        private void MethodAddSubjects()
        {
            System.Windows.MessageBox.Show("ADD Subjects!!!");
        }

        private void MethodEditSubjects()
        {
            System.Windows.MessageBox.Show("Edit Subjects!!!");
        }
        private void MethodDeleteSubjects()
        {
            System.Windows.MessageBox.Show("Delete Subjects!!!");
        }

        private void tabcontrol1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch(tabcontrol1.SelectedIndex)
            {
                case 0:
                    StackPanel.SetZIndex(panel0, 2);
                    panel0.Opacity = 1;
                    StackPanel.SetZIndex(panel1,1);
                    StackPanel.SetZIndex(panel2, 0);
                    panel1.Opacity = 0;
                    panel2.Opacity = 0;
                    //LoadSubjects();
                    break;

                case 1:
                    StackPanel.SetZIndex(panel1, 2);
                    panel1.Opacity = 1;
                    StackPanel.SetZIndex(panel0,1);
                    StackPanel.SetZIndex(panel2, 0);
                    panel0.Opacity = 0;
                    panel2.Opacity = 0;
                    break;

                case 2:
                    StackPanel.SetZIndex(panel2, 2);
                    panel2.Opacity = 1;
                    StackPanel.SetZIndex(panel1,1);
                    StackPanel.SetZIndex(panel0, 0);
                    panel1.Opacity = 0;
                    panel0.Opacity = 0;
                    //LoadGroups();
                    break;

            }
        }

        private void tabItem1ButtonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Method_AddSubjects();
        }

        private void tabItem1ButtonDelete_Click_1(object sender, RoutedEventArgs e)
        {
            //Method_DeleteSubjects();
            var item = tabItem1ListView.SelectedItem;
            if (item != null)
            {
                DataRowView row = item as DataRowView;
                //proxy.deleteGroup((int)row["id"]);
            }
        }

        private void tabItem1ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            Method_EditSubjects();
        }

        private void tabItem1ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            Method_FindSubjects();
        }

        private void tabItem2ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Method_AddTutor();
        }

        private void tabItem2ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Method_DeleteTutor();
        }

        private void tabItem2ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Method_EditTutor();
        }

        private void tabItem2ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            Method_FindTutor();
        }

        private void tabItem3ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Method_AddGroup();
        }

        private void tabItem3ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Method_DeleteGroup();
        }

        private void tabItem3ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Method_EditGroup();
        }

        private void tabItem3ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            Method_FindGroup();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Method_AddSubjects();
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Method_EditSubjects();
        }

        private void Image_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Method_DeleteSubjects();
        }

        private void Image_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            Method_FindSubjects();
        }

        private void Image_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            Method_HelpSubjects();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Method_AddTutor();
        }

        private void Image_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            Method_EditTutor();
        }

        private void Image_MouseDown_7(object sender, MouseButtonEventArgs e)
        {
            Method_DeleteTutor();
        }

        private void Image_MouseDown_8(object sender, MouseButtonEventArgs e)
        {
            Method_FindTutor();
        }

        private void Image_MouseDown_9(object sender, MouseButtonEventArgs e)
        {
            Method_HelpTutor();
        }

        private void Image_MouseDown_10(object sender, MouseButtonEventArgs e)
        {
            Method_AddGroup();
        }

        private void Image_MouseDown_11(object sender, MouseButtonEventArgs e)
        {
            Method_EditGroup();
        }

        private void Image_MouseDown_12(object sender, MouseButtonEventArgs e)
        {
            Method_DeleteGroup();
        }

        private void Image_MouseDown_13(object sender, MouseButtonEventArgs e)
        {
            Method_FindGroup();
        }

        private void Image_MouseDown_14(object sender, MouseButtonEventArgs e)
        {
            Method_HelpGroup();
        }

        private void Method_AddSubjects()
        {
            //WindowSubject winS = new WindowSubject();
            //if (winS.ShowDialog() == DialogResult.OK)
            //{
                
            //}

        }

        private void Method_DeleteSubjects()
        {
            System.Windows.MessageBox.Show("Delete Subjects!!!");
        }

        private void Method_EditSubjects()
        {
            System.Windows.MessageBox.Show("Edit Subjects!!!");
        }

        private void Method_FindSubjects()
        {
            System.Windows.MessageBox.Show("FIND Subjects!!!");
        }

        private void Method_HelpSubjects()
        {
            System.Windows.MessageBox.Show("HELP Subjects!!!");
        }

        private void Method_AddTutor()
        {
            System.Windows.MessageBox.Show("ADD TUTOR!!!");
        }

        private void Method_DeleteTutor()
        {
            System.Windows.MessageBox.Show("Delete TUTOR!!!");
        }

        private void Method_EditTutor()
        {
            System.Windows.MessageBox.Show("Edit TUTOR!!!");
        }

        private void Method_FindTutor()
        {
            System.Windows.MessageBox.Show("FIND TUTOR!!!");
        }

        private void Method_HelpTutor()
        {
            System.Windows.MessageBox.Show("HELP TUTOR!!!");
        }

        private void Method_AddGroup()
        {
            System.Windows.MessageBox.Show("ADD GROUP!!!");
        }

        private void Method_DeleteGroup()
        {
            System.Windows.MessageBox.Show("Delete GROUP!!!");
        }

        private void Method_EditGroup()
        {
            System.Windows.MessageBox.Show("Edit GROUP!!!");
        }

        private void Method_FindGroup()
        {
            System.Windows.MessageBox.Show("FIND GROUP!!!");
        }

        private void Method_HelpGroup()
        {
            System.Windows.MessageBox.Show("HELP GROUP!!!");
        }

        private void tabItem1ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                DataRowView row = item as DataRowView;
                MessageBox.Show(row["name"].ToString());
            }
            
        }

        private void tabItem3_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("VIBRANO");
        }


    }
}
