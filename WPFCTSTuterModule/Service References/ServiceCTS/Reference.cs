﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFCTSTuterModule.ServiceCTS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCTS.IServiceCTS")]
    public interface IServiceCTS {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetSubjectsDataTable", ReplyAction="http://tempuri.org/IServiceCTS/GetSubjectsDataTableResponse")]
        System.Data.DataTable GetSubjectsDataTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetSubjectsDataTable", ReplyAction="http://tempuri.org/IServiceCTS/GetSubjectsDataTableResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetSubjectsDataTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetTestsDataTableBySubjectId", ReplyAction="http://tempuri.org/IServiceCTS/GetTestsDataTableBySubjectIdResponse")]
        System.Data.DataTable GetTestsDataTableBySubjectId(int subjectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetTestsDataTableBySubjectId", ReplyAction="http://tempuri.org/IServiceCTS/GetTestsDataTableBySubjectIdResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetTestsDataTableBySubjectIdAsync(int subjectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetQuestionsDataTableByTestId", ReplyAction="http://tempuri.org/IServiceCTS/GetQuestionsDataTableByTestIdResponse")]
        System.Data.DataTable GetQuestionsDataTableByTestId(int testId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetQuestionsDataTableByTestId", ReplyAction="http://tempuri.org/IServiceCTS/GetQuestionsDataTableByTestIdResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetQuestionsDataTableByTestIdAsync(int testId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetQuestionById", ReplyAction="http://tempuri.org/IServiceCTS/GetQuestionByIdResponse")]
        DBLibrary.Question GetQuestionById(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetQuestionById", ReplyAction="http://tempuri.org/IServiceCTS/GetQuestionByIdResponse")]
        System.Threading.Tasks.Task<DBLibrary.Question> GetQuestionByIdAsync(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetAnswersDataTableByQuestionId", ReplyAction="http://tempuri.org/IServiceCTS/GetAnswersDataTableByQuestionIdResponse")]
        System.Data.DataTable GetAnswersDataTableByQuestionId(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetAnswersDataTableByQuestionId", ReplyAction="http://tempuri.org/IServiceCTS/GetAnswersDataTableByQuestionIdResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetAnswersDataTableByQuestionIdAsync(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/DrawQuestionById", ReplyAction="http://tempuri.org/IServiceCTS/DrawQuestionByIdResponse")]
        string DrawQuestionById(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/DrawQuestionById", ReplyAction="http://tempuri.org/IServiceCTS/DrawQuestionByIdResponse")]
        System.Threading.Tasks.Task<string> DrawQuestionByIdAsync(int questionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetUsersCount", ReplyAction="http://tempuri.org/IServiceCTS/GetUsersCountResponse")]
        int GetUsersCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetUsersCount", ReplyAction="http://tempuri.org/IServiceCTS/GetUsersCountResponse")]
        System.Threading.Tasks.Task<int> GetUsersCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetUsersDataTable", ReplyAction="http://tempuri.org/IServiceCTS/GetUsersDataTableResponse")]
        System.Data.DataTable GetUsersDataTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/GetUsersDataTable", ReplyAction="http://tempuri.org/IServiceCTS/GetUsersDataTableResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetUsersDataTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/IIsLifeGood", ReplyAction="http://tempuri.org/IServiceCTS/IIsLifeGoodResponse")]
        bool IIsLifeGood();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCTS/IIsLifeGood", ReplyAction="http://tempuri.org/IServiceCTS/IIsLifeGoodResponse")]
        System.Threading.Tasks.Task<bool> IIsLifeGoodAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCTSChannel : WPFCTSTuterModule.ServiceCTS.IServiceCTS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCTSClient : System.ServiceModel.ClientBase<WPFCTSTuterModule.ServiceCTS.IServiceCTS>, WPFCTSTuterModule.ServiceCTS.IServiceCTS {
        
        public ServiceCTSClient() {
        }
        
        public ServiceCTSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCTSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCTSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCTSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetSubjectsDataTable() {
            return base.Channel.GetSubjectsDataTable();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetSubjectsDataTableAsync() {
            return base.Channel.GetSubjectsDataTableAsync();
        }
        
        public System.Data.DataTable GetTestsDataTableBySubjectId(int subjectId) {
            return base.Channel.GetTestsDataTableBySubjectId(subjectId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetTestsDataTableBySubjectIdAsync(int subjectId) {
            return base.Channel.GetTestsDataTableBySubjectIdAsync(subjectId);
        }
        
        public System.Data.DataTable GetQuestionsDataTableByTestId(int testId) {
            return base.Channel.GetQuestionsDataTableByTestId(testId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetQuestionsDataTableByTestIdAsync(int testId) {
            return base.Channel.GetQuestionsDataTableByTestIdAsync(testId);
        }
        
        public DBLibrary.Question GetQuestionById(int questionId) {
            return base.Channel.GetQuestionById(questionId);
        }
        
        public System.Threading.Tasks.Task<DBLibrary.Question> GetQuestionByIdAsync(int questionId) {
            return base.Channel.GetQuestionByIdAsync(questionId);
        }
        
        public System.Data.DataTable GetAnswersDataTableByQuestionId(int questionId) {
            return base.Channel.GetAnswersDataTableByQuestionId(questionId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetAnswersDataTableByQuestionIdAsync(int questionId) {
            return base.Channel.GetAnswersDataTableByQuestionIdAsync(questionId);
        }
        
        public string DrawQuestionById(int questionId) {
            return base.Channel.DrawQuestionById(questionId);
        }
        
        public System.Threading.Tasks.Task<string> DrawQuestionByIdAsync(int questionId) {
            return base.Channel.DrawQuestionByIdAsync(questionId);
        }
        
        public int GetUsersCount() {
            return base.Channel.GetUsersCount();
        }
        
        public System.Threading.Tasks.Task<int> GetUsersCountAsync() {
            return base.Channel.GetUsersCountAsync();
        }
        
        public System.Data.DataTable GetUsersDataTable() {
            return base.Channel.GetUsersDataTable();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetUsersDataTableAsync() {
            return base.Channel.GetUsersDataTableAsync();
        }
        
        public bool IIsLifeGood() {
            return base.Channel.IIsLifeGood();
        }
        
        public System.Threading.Tasks.Task<bool> IIsLifeGoodAsync() {
            return base.Channel.IIsLifeGoodAsync();
        }
    }
}
