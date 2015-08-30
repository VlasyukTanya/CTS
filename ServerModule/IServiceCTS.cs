using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DBLibrary;
using System.Data;

namespace ServerModule
{
    [ServiceContract]
    public interface IServiceCTS
    {
        [OperationContract]
        DataTable GetSubjectsDataTable();

        [OperationContract]
        DataTable GetTestsDataTableBySubjectId(int subjectId);

        [OperationContract]
        DataTable GetQuestionsDataTableByTestId(int testId);

        [OperationContract]
        Question GetQuestionById(int questionId);

        [OperationContract]
        DataTable GetAnswersDataTableByQuestionId(int questionId);

        [OperationContract]
        string DrawQuestionById(int questionId);
        [OperationContract]
        bool AuthenticateUser(string username, string password);
        [OperationContract]
        int GetUsersCount();
        [OperationContract]
        DataTable GetUsersDataTable();
        [OperationContract]
        bool IIsLifeGood();
        [OperationContract]
        void addUserTest(int id_user, int id_test, int numberOfTries, float mark, bool ifAvailable, DateTime testTime, bool canSkip, bool canBack, int testContinuesTime);
    }
}
