using System;
using System.Data;

namespace DBLibrary
{
    public class Test
    {
        DBDriver db;
        int id;
        string name;
        string creationDate;
        string lastEditDate;
        int subjectId;
        int questionNum;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string CreationDate
        {
            get { return this.creationDate; }
            set { this.creationDate = value; }
        }
        public string LastEditDate
        {
            get { return this.LastEditDate; }
            set { this.LastEditDate = value; }
        }
        public int SubjectId
        {
            get { return this.subjectId; }
            set { this.subjectId = value; }
        }
        public int QuestionNum
        {
            get { return this.questionNum; }
            set { this.questionNum = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Test(DBDriver db)
        {
            this.db = db;
        }
        public Test(DBDriver db, int id, string name, string lastEditDate, string creationDate, int subjectId, int questionNum)
        {
            this.db = db;
            this.id = id;
            this.name = name;
            this.lastEditDate = lastEditDate;
            this.creationDate = creationDate;
            this.subjectId = subjectId;
            this.questionNum = questionNum;
        }

        public Test Create()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE tests_create N'{0}', {1}, {2}", this.name, this.subjectId, this.questionNum));
            return new Test(this.db, (int)res.Rows[0]["id"], this.name, null, ((DateTime)res.Rows[0]["REGDATE"]).ToString(), this.subjectId, this.questionNum);
        }
        public Test Get(int id)
        {
            DataTable res = this.db.ExecuteQuery(String.Format("SELECT * FROM tests WHERE id = {0}",id));
            return new Test(this.db, id, (string)res.Rows[0]["id"], ((DateTime)res.Rows[0]["last_edit_date"]).ToString(), ((DateTime)res.Rows[0]["creation_date"]).ToString(), (int)res.Rows[0]["subject_id"], (int)res.Rows[0]["question_num"]);

        }
        public Test Update()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE tests_update {0}, N'{1}', {2}, {3}",this.id, this.name, this.subjectId, this.questionNum));
            return new Test(this.db, this.id, this.name, ((DateTime)res.Rows[0]["EDITDATE"]).ToString(), this.creationDate, this.subjectId, this.questionNum);
        }
        public void Delete()
        {
            this.db.ExecuteNonQuery(String.Format("DELETE FROM tests WHERE id = {0}", this.id));
        }
        static public DataTable GetTestsDataTable(DBDriver db)
        {
            return db.ExecuteQuery(String.Format(@"SELECT * FROM tests"));
        }
        static public DataTable GetTestsDataTableBySubjectId(DBDriver db, int subjectId)
        {
            return db.ExecuteQuery(String.Format(@"SELECT * FROM tests WHERE subject_id = {0}", subjectId));
        }
    }
}
