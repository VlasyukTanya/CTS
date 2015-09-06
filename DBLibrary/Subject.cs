using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace DBLibrary
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public DBDriver db;
        [DataMember]
        public int id;
        [DataMember]
        public string name;      

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Subject(DBDriver db)
        {
            this.db = db;
        }
        public Subject(DBDriver db, int id, string name)
        {
            this.db = db;
            this.id = id;
            this.name = name;            
        }

        public Subject Create()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE insertOfSubjects N'{0}'", this.name));
            return new Subject(this.db, (int)res.Rows[0]["id"], this.name);
        }
        public Subject Get(int id)
        {
            DataTable res = this.db.ExecuteQuery(String.Format("SELECT * FROM subjects WHERE id = {0}", id));
            return new Subject(this.db, id, (string)res.Rows[0]["name"]);
        }
        static public DataTable GetSubjectsDataTable(DBDriver db)
        {
            try
            {
                return db.ExecuteQuery(String.Format(@"SELECT * FROM subjects"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }
        //public Test Update()
        //{
        //    //DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE tests_update {0}, N'{1}', {2}, {3}", this.id, this.name, this.subjectId, this.questionNum));
        //    //return new Test(this.db, this.id, this.name, ((DateTime)res.Rows[0]["EDITDATE"]).ToString(), this.creationDate, this.subjectId, this.questionNum);
        //}
        //public void Delete()
        //{
        //    this.db.ExecuteNonQuery(String.Format("DELETE FROM tests WHERE id = {0}", this.id));
        //}
    }
}
