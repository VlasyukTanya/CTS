using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace DBLibrary
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public DBDriver db;
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public string registrationDate;
        [DataMember]
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

        public Group Create()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE InsertOfGroups N'{0}'", this.name, this.registrationDate));
            return new Group(this.db, (int)res.Rows[0]["id"], this.name, this.registrationDate);
        }

        public Group Get(int id)
        {
            DataTable res = this.db.ExecuteQuery(String.Format("SELECT * FROM groups WHERE id = {0}", id));
            return new Group(this.db, id, (string)res.Rows[0]["name"], (string)res.Rows[0]["registrationDate"], (string)res.Rows[0]["lastEditDate"]);
        }

        static public DataTable GetGroupsDataTable(DBDriver db)
        {
            try
            {
                return db.ExecuteQuery(String.Format(@"SELECT * FROM groups"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }         
        }

        public Group Update()
        {
            DataTable res = this.db.ExecuteQuery(String.Format("EXECUTE groups_update {0}, N'{1}', N'{2}'", this.id, this.name, this.registrationDate));
            return new Group(this.db, this.id, this.name, this.registrationDate, ((DateTime)res.Rows[0]["EDITDATE"]).ToString());
        }

        public void Delete()
        {
            this.db.ExecuteNonQuery(String.Format("DELETE FROM groups WHERE id = {0}", this.id));
        }
    }
}