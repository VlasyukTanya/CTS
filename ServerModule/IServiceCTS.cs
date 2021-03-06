﻿using System;
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

        [OperationContract]
        void delUser(int id);

        [OperationContract]
        void addUser(string name, string passwd, string realName, string email, int roleId, int groupId);

        [OperationContract]
        DataTable GetTutorsDataTable();

        [OperationContract]
        DataTable GetGroupsDataTable();

        [OperationContract]
        void addSubject(string name_subject);

        [OperationContract]
        void deleteSubject(int id_subject);

        [OperationContract]
        DataTable GetTestsForUser(int userId);

        [OperationContract]
        void updateSubject(int id_subject, string name_subject);

        [OperationContract]
        void addGroup(string name_group);

        [OperationContract]
        void deleteGroup(int id_group);

        [OperationContract]
        void updateGroup(int id_group, string name_group);

        [OperationContract]
        void addTutor(string name, string passwd, string realName, string email, AdditionalContacts additionalContacts, int roleId, int groupId);

        [OperationContract]
        User updateTutor(int id, string name, string passwd, string realName, string email, AdditionalContacts additionalContacts, string lastEditDate, int roleId, int groupId);  
    }
}
