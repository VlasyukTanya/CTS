using System;
using System.Data;
using System.Runtime.Serialization;

namespace DBLibrary
{
    [DataContract]
    public class Question
    {
        DBDriver db;
        int id;
        string questionText;
        bool active;
        int questionTypeId;
        int testId;
        int answerNum;
        int categoryId;
        [DataMember]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [DataMember]
        public string QuestionText
        {
            get { return this.questionText; }
            set { this.questionText = value; }
        }
        [DataMember]
        public bool Status
        {
            get { return this.active; }
            set { this.active = value; }
        }
        [DataMember]
        public int QuestionTypeId
        {
            get { return this.questionTypeId; }
            set { this.questionTypeId = value; }
        }
        [DataMember]
        public int TestId
        {
            get { return this.testId; }
            set { this.testId = value; }
        }
        [DataMember]
        public int AunswerNum
        {
            get { return this.answerNum; }
            set { this.answerNum= value; }
        }
        [DataMember]
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }
       
        public Question(DBDriver db)
        {
            this.db = db;
        }
        public Question(DBDriver db, int id, string questionText, bool active, int questionTypeId, int testId, int answerNum, int categoryId)
        {
            this.db = db;
            this.id = id;
            this.questionText = questionText;
            this.active = active;
            this.questionTypeId = questionTypeId;
            this.testId = testId;
            this.answerNum = answerNum;
            this.categoryId = categoryId;
        }

        public Question Create()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("INSERT INTO questions(question_text, active, question_type_id, test_id, answer_num, category_id) OUTPUT Inserted.id AS id VALUES('{0}', {1}, {2}, {3}, {4}, {5})", this.questionText, this.active ? 1 : 0, this.questionTypeId, this.testId, this.answerNum, this.categoryId));
            return new Question(this.db, (int)res.Rows[0]["id"], this.questionText, this.active, this.questionTypeId, this.testId, this.answerNum, this.categoryId);
        }
        public Question Get(int id)
        {
            DataTable res = this.db.ExecuteQuery(String.Format("SELECT * FROM questions WHERE id = {0}", id));
            return new Question(this.db, id, (string)res.Rows[0]["question_text"], (bool)res.Rows[0]["active"], (int)res.Rows[0]["question_type_id"], (int)res.Rows[0]["test_id"], (int)res.Rows[0]["answer_num"], (int)res.Rows[0]["category_id"]);

        }
        public Question Update()
        {
            this.db.ExecuteNonQuery(String.Format("UPDATE questions SET question_text = '{0}', active = {1}, question_type_id = {2}, test_id = {3}, answer_num = {4}, category_id = {5} WHERE id = {6}", this.questionText, this.active ? 1 : 0, this.questionTypeId, this.testId, this.answerNum, this.categoryId, this.id));
            return this;
        }
        public void Delete()
        {
            this.db.ExecuteNonQuery(String.Format("DELETE FROM questions WHERE id = {0}", this.id));
        }
        static public DataTable GetQuestionsDataTableByTestId(DBDriver db, int testId)
        {
            return db.ExecuteQuery(String.Format(@"SELECT * FROM questions WHERE test_id = {0}", testId));
        }
    }
}
