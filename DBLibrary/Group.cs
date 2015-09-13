using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace DBLibrary
{
    [DataContract]
    public class Group
    {
        //[DataMember]
        public DBDriver db;
        //[DataMember]
        public int id;
        //[DataMember]
        public string name;
        //[DataMember]
        public string registrationDate;
        //[DataMember]
        public string lastEditDate;

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

        public string RegistrationDate
        {
            get { return this.registrationDate; }
            set { this.registrationDate = value; }
        }

        public string LastEditDate
        {
            get { return this.lastEditDate; }
            set { this.lastEditDate = value; }
        }

        public Group(DBDriver db)
        {
            this.db = db;
        }

        public Group(DBDriver db, string name)
        {
            this.db = db;
            this.name = name;
        }

        public Group(DBDriver db, int id, string name)
        {
            this.db = db;
            this.id = id;
            this.name = name;
        }

        public Group(DBDriver db, int id, string name, string registrationDate)
        {
            this.db = db;
            this.id = id;
            this.name = name;
            this.registrationDate = registrationDate;
        }

         public Group(DBDriver db, int id, string name, string registrationDate, string lastEditDate)
        {
            this.db = db;
            this.id = id;
            this.name = name;
            this.registrationDate = registrationDate;
             this.lastEditDate = lastEditDate;
        }

        public void Create()
        {
            this.db.ExecuteNonQuery(String.Format("EXECUTE groups_add N'{0}'", this.name));
        }

        public Group Get(int id)
        {
            DataTable result = this.db.ExecuteQuery(String.Format("SELECT * FROM groups WHERE id = {0}", id));
            if (result.Rows.Count < 1)
                return null;
            return new Group(
                this.db,
                (int)result.Rows[0]["id"],
                (string)result.Rows[0]["name"], 
                ((DateTime)result.Rows[0]["registration_date"]).ToString(),
                !result.Rows[0].IsNull("last_edit_date") ? ((DateTime)result.Rows[0]["last_edit_date"]).ToString() : null);
        }

        static public DataTable GetGroupsDataTable(DBDriver db)
        {
            try
            {
                return db.ExecuteQuery(String.Format(@"SELECT * FROM groups order by id"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }         
        }

        public void Update()
        {
            this.db.ExecuteNonQuery(String.Format("EXECUTE groups_update {0}, N'{1}'", this.id, this.name));
        }

        public void Delete()
        {
            try
            {
                db.ExecuteNonQuery(String.Format(@"DELETE FROM groups WHERE id = {0}", this.id));
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