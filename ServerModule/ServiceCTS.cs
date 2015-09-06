using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DBLibrary;
using System.Data;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Forms;

namespace ServerModule
{
    public class ServiceCTS : IServiceCTS
    {
        DBDriver db = new DBDriver(@"SQL5016.Smarterasp.net", @"DB_9D003D_cts1_admin", @"cts1CoolDbUser", @"db_9d003d_cts1");
        public int GetUsersCount()
        {
            DataTable dt = User.GetUsersDataTable(db);
            return dt.Rows.Count;
        }
        public DataTable GetUsersDataTable()
        {
            DataTable dt = User.GetUsersDataTable(db);
            dt.TableName = "users";
            return dt;
        }
        public bool IIsLifeGood()
        {
            return true;
        }
        public DataTable GetSubjectsDataTable()
        {
            try
            {
                DataTable dt = Subject.GetSubjectsDataTable(db);
                dt.TableName = "subjects"; //Нужно явно указать имя таблицы, вот не помню зачем, может и не для этого случая)
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

        public bool AuthenticateUser(string username, string password)
        {
            User user = new User(db);
            user.Name = username;
            user.Password = password;
            return user.CheckIfExists();
        }

        public DataTable GetTestsDataTableBySubjectId(int subjectId)
        {
            DataTable dt = Test.GetTestsDataTableBySubjectId(db, subjectId);
            dt.TableName = "tests";
            return dt;
        }
        public DataTable GetQuestionsDataTableByTestId(int testId)
        {
            DataTable dt = Question.GetQuestionsDataTableByTestId(db, testId);
            dt.TableName = "questions";
            return dt;
        }
        public DataTable GetAnswersDataTableByQuestionId(int questionId)
        {
            DataTable dt = Answer.GetAnswersDataTableByQuestionId(db, questionId);
            dt.TableName = "answers";
            return dt;
        }

        public Question GetQuestionById(int questionId)
        {
            Question q = new Question(db);
            return q.Get(questionId);
        }
        public string DrawQuestionById(int questionId)
        {
            Question q = new Question(db);
            Question qq = q.Get(questionId);
            DataTable dt = this.GetAnswersDataTableByQuestionId(questionId);
            StringBuilder sb = new StringBuilder();
            //if (q.QuestionTypeId == 1) //TODO: в зависимости от типа вопрос будет выглядить по разному
            if (true)
            {
                sb.Append(@"<StackPanel xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>");
                sb.Append(String.Format(@"<TextBlock xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' Margin='12, 12, 12, 0' TextWrapping='Wrap' Text='{0}'></TextBlock>", qq.QuestionText));
                foreach (DataRow dr in dt.Rows)
                {                    
                    sb.Append(String.Format(@"<RadioButton GroupName = 'Os' Content = '{0}' IsChecked = 'False' />", dr["answer_text"]));
                }
                sb.Append("</StackPanel>");
            }
            else
            {
                //
            }
            return sb.ToString();
        }

        public void addUserTest(int id_user, int id_test, int numberOfTries, float mark, bool ifAvailable, DateTime testTime, bool canSkip, bool canBack, int testContinuesTime)
        {
            User_test ut = new User_test(db, id_user, id_test, numberOfTries, mark, ifAvailable, testTime, canSkip, canBack, testContinuesTime);
            ut.Create();
        }



//**********************************************************************************************************
        //Subject addSubject(int id_subject, string name_subject);

        //void deleteSubject(int id_subject);

        //Subject updateSubject(int id_subject, string name_subject);

        public DataTable GetGroupsDataTable()
        {
            try
            {
                DataTable dt = Group.GetGroupsDataTable(db);
                dt.TableName = "groups";
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

/*
        public Group addGroup(int id_group, string name_group, string registrationDate_group)
        {
            return new Group(db, id_group, name_group, registrationDate_group).Create();
        }

        public void deleteGroup(int id_group)
        {
            Group gr = new Group(db);
            gr.Delete();
        }

        public Group updateGroup(int id_group, string name_group, string registrationDate_group)
        {
            Group gr = new Group(db, id_group, name_group, registrationDate_group);
            return gr.Update();
        }
*/
        public DataTable GetTutorsDataTable()
        {
            DataTable dt = User.GetTutorsDataTable(db);
            dt.TableName = "tutors";
            return dt;
        }

        //User addTutor(int id, string name, string passwd, string realName, string email, AdditionalContacts additionalContacts, string registrationDate, int roleId, int groupId);

        //void deleteTutor(int id_user);

        //User updateTutor(int id, string name, string passwd, string realName, string email, AdditionalContacts additionalContacts, string lastEditDate, int roleId, int groupId);
    }
}
