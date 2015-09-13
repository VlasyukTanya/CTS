using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Data.SqlClient;


namespace DBLibrary
{
    [DataContract]
    public class Subject
    {
        //[DataMember]
        public DBDriver db;
        //[DataMember]
        public int id;
        //[DataMember]
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

        public Subject(DBDriver db, string name)
        {
            this.db = db;
            this.name = name;
        }

        public Subject(DBDriver db, int id, string name)
        {
            this.db = db;
            this.id = id;
            this.name = name;            
        }

        public void Create()
        {
            this.db.ExecuteNonQuery(String.Format("EXECUTE InsertOfSubjects N'{0}'", this.name));
            //return new Subject(this.db, (int)res.Rows[0]["id"], (string)res.Rows[0]["name"]);
        }
        public Subject Get(int id)
        {
            DataTable result = this.db.ExecuteQuery(String.Format("SELECT * FROM subjects WHERE id = {0}", id));
            if (result.Rows.Count < 1)
                return null;
            return new Subject(this.db, (int)result.Rows[0]["id"], (string)result.Rows[0]["name"]);
        }
        static public DataTable GetSubjectsDataTable(DBDriver db)
        {
            try
            {
                return db.ExecuteQuery(String.Format(@"SELECT * FROM subjects order by id"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

        public void Update()
        {
            this.db.ExecuteNonQuery(String.Format("EXECUTE subjects_update {0}, N'{1}'", this.id, this.name));
        }

        public void Delete()
        {
            try
            {
                db.ExecuteNonQuery(String.Format(@"DELETE FROM subjects WHERE id = {0}", this.id));
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
