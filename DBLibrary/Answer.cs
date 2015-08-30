using System;
using System.Data;

namespace DBLibrary
{
    public class Answer
    {
        DBDriver db;
        int id;
        string answerText;
        bool rightAnswer;
        int parentId;
        int questionId;
        bool training;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string AnswerText
        {
            get { return this.answerText; }
            set { this.answerText = value; }
        }
        public bool IsRight
        {
            get { return this.rightAnswer; }
            set { this.rightAnswer = value; }
        }
        public int ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }
        public int QuestionId
        {
            get { return this.questionId; }
            set { this.questionId = value; }
        }
        public bool IsTraining
        {
            get { return this.training; }
            set { this.training = value; }
        }

        public Answer(DBDriver db)
        {
            this.db = db;
        }
        public Answer(DBDriver db, int id, string answerText, bool rightAnswer, int parentId, int questionId, bool training)
        {
            this.db = db;
            this.id = id;
            this.answerText = answerText;
            this.rightAnswer = rightAnswer;
            this.parentId = parentId;
            this.questionId = questionId;
            this.training = training;
        }

        public Answer Create()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("INSERT INTO answers(answer_text, right_answer, parent_id, question_id, training) OUTPUT Inserted.id AS id VALUES('{0}', {1}, {2}, {3}, {4}, )", this.answerText, this.rightAnswer ? 1 : 0, this.parentId, this.questionId, this.training ? 1 : 0));
            return new Answer(this.db, (int)res.Rows[0]["id"], this.answerText, this.rightAnswer, this.parentId, this.questionId, this.training);
        }
        public Answer Get(int id)
        {
            DataTable res = this.db.ExecuteQuery(String.Format("SELECT * FROM answers WHERE id = {0}", id));
            return new Answer(this.db, id, (string)res.Rows[0]["answer_text"], (bool)res.Rows[0]["right_answer"], (int)res.Rows[0]["parent_id"], (int)res.Rows[0]["question_id"], (bool)res.Rows[0]["training"]);

        }
        public Answer Update()
        {
            this.db.ExecuteNonQuery(String.Format("UPDATE answers SET answer_text = '{0}', right_answer = {1}, parent_id = {2}, question_id = {3}, training = {4} WHERE id = {5}", this.answerText, this.rightAnswer ? 1 : 0, this.parentId, this.questionId, this.training ? 1 : 0, this.id));
            return this;
        }
        public void Delete()
        {
            this.db.ExecuteNonQuery(String.Format("DELETE FROM answers WHERE id = {0}", this.id));
        }
        static public DataTable GetAnswersDataTableByQuestionId(DBDriver db, int questionId)
        {
            return db.ExecuteQuery(String.Format(@"SELECT * FROM answers WHERE question_id = {0}", questionId));
        }
    }
}
