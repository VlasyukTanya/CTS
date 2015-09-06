using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Runtime.Serialization;

namespace DBLibrary
{
    public struct AdditionalContact
    {
        public string service;
        public string contacts;
    }

    public class AdditionalContacts
    {
        List<AdditionalContact> parameters;
        public AdditionalContacts()
        {
            this.parameters = new List<AdditionalContact>();
        }
        public AdditionalContacts(string data)
        {
            this.parameters = new List<AdditionalContact>();
            string[] splitted = data.Split(';');
            foreach (string splitted_item in splitted)
            {
                try
                {
                    if (splitted_item.Length > 0)
                    {
                        string[] splitted_item_splitted = splitted_item.Split(':');
                        AdditionalContact contact = new AdditionalContact();
                        contact.service = splitted_item_splitted[0];
                        contact.contacts = splitted_item_splitted[1];
                        parameters.Add(contact);
                    }
                }
                catch(Exception e)
                {
                    throw new FormatException("Can't deserialize class. Check string format. " + e.Message);
                }
            }
        }
        public static AdditionalContacts deserialize(string data)
        {
            return new AdditionalContacts(data);
        }

        public string Serialize()
        {
            return this.ToString();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (AdditionalContact param in this.parameters)
            {
                builder.Append(String.Format("{0}:{1};", param.service, param.contacts));
            }
            return builder.ToString();
        }
        public List<AdditionalContact> Contacts
        {
            get { return this.parameters; }
        }
        public void Add(string service, string contact)
        {
            AdditionalContact new_contact = new AdditionalContact();
            new_contact.service = service;
            new_contact.contacts = contact;
            this.parameters.Add(new_contact);
        }
    }

    [DataContract]
    public class User
    {
        DBDriver db;
        int id;
        string name;
        string passwd;
        string realName;
        string email;
        AdditionalContacts additionalContacts;
        string lastLoginDate;
        string registrationDate;
        string lastEditDate;
        int roleId;
        int groupId;

        public User(
            DBDriver db, 
            int id, 
            string name, 
            string passwd, 
            string realName, 
            string email, 
            AdditionalContacts additionalContacts, 
            string lastLoginDate, 
            string registrationDate, 
            string lastEditDate, 
            int roleId, 
            int groupId
            )
        {
            this.db = db;
            this.id = id;
            this.name = name;
            this.passwd = passwd;
            this.realName = realName;
            this.email = email;
            this.additionalContacts = additionalContacts;
            this.registrationDate = registrationDate;
            this.lastEditDate = lastEditDate;
            this.lastLoginDate = lastLoginDate;
            this.roleId = roleId;
            this.groupId = groupId;
        }
        public User(
            DBDriver db, 
            int id,
            string name,
            string passwd, 
            string realName, 
            string email, 
            AdditionalContacts additionalContacts, 
            string registrationDate, 
            int roleId, 
            int groupId
            )
        {
            this.db = db;
            this.id = id;
            this.name = name;
            this.passwd = passwd;
            this.realName = realName;
            this.email = email;
            this.additionalContacts = additionalContacts;
            this.registrationDate = registrationDate;
            this.roleId = roleId;
            this.groupId = groupId;
        }
        public User(DBDriver db)
        {
            this.db = db;
        }
        public int Id
        {
            get { return this.id; }
            set { this.Id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Password
        {
            get { return this.passwd; }
            set { this.passwd = value; }
        }
        public string RealName
        {
            get { return this.realName; }
            set { this.realName = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public AdditionalContacts Contacts
        {
            get { return this.additionalContacts; }
            set { this.additionalContacts = value; }
        }
        public string LastLoginDate
        {
            get { return this.lastLoginDate; }
            set { this.lastLoginDate = value; }
        }
        public string LastEditDate
        {
            get { return this.lastEditDate; }
            set { this.lastEditDate = value; }
        }
        public string RegistrationDate
        {
            get { return this.registrationDate; }
            set { this.registrationDate = value; }
        }
        public int GroupId
        {
            get { return this.groupId; }
            set { this.groupId = value; }
        }
        public int RoleId
        {
            get { return this.roleId; }
            set { this.roleId = value; }
        }
        public bool CheckIfExists()
        {
            DataTable result = null;
            bool res = false;
            try
            {
                result = db.ExecuteQuery(String.Format("SELECT dbo.users_check(N'{0}', '{1}') AS RESULT", this.name, this.passwd));
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (result != null)
                {
                    if (result.Rows.Count == 1)
                    {
                        if ((bool)result.Rows[0]["RESULT"])
                            res = true;
                        result.Dispose();
                    }
                        
                }
            }
            return res;
        }
        public bool SignIn()
        {
            DataTable result = null;
            bool res = false;
            try
            {
                result = db.ExecuteQuery(String.Format("EXECUTE dbo.users_sign_in {0}, {1}", this.name, this.passwd));
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (result != null)
                {
                    if (result.Rows.Count == 1)
                    {
                        if ((int)result.Rows[0]["RESULT"] == 1)
                            res = true;
                        result.Dispose();
                    }

                }
            }
            return res;
        }
        public User Create()
        {
            DataTable result = null;
            if (this.additionalContacts == null)
                result = this.db.ExecuteQuery(
                    string.Format(
                        @"EXECUTE dbo.users_add N'{0}', '{1}', N'{2}', N'{3}', {4}, {5}, {6};",
                        this.name,
                        this.passwd,
                        this.realName,
                        this.email,
                        "NULL",
                        this.roleId,
                        this.groupId
                        )
                );
            else
            {
                result = this.db.ExecuteQuery(
                    string.Format(
                        @"EXECUTE dbo.users_add N'{0}', '{1}', N'{2}', N'{3}', N'{4}', {5}, {6};",
                        this.name,
                        this.passwd,
                        this.realName,
                        this.email,
                        this.additionalContacts.ToString(),
                        this.roleId,
                        this.groupId
                        )
                );
            }
            return new User(
                this.db, 
                (int)result.Rows[0]["ID"], 
                this.name, 
                this.passwd, 
                this.realName, 
                this.email, 
                this.additionalContacts, 
                ((DateTime)result.Rows[0]["REGDATE"]).ToString(),
                this.roleId, 
                this.groupId);
        }
        public User Update()
        {
            try
            {
                DataTable result = null;
                if (this.additionalContacts == null)
                    result = db.ExecuteQuery(
                    string.Format(
                        @"EXECUTE dbo.users_update {0}, N'{1}', '{2}', N'{3}', N'{4}', {5}, {6}, {7};",
                        this.id,
                        this.name,
                        this.passwd,
                        this.realName,
                        this.email,
                        "NULL",
                        this.roleId,
                        this.groupId
                        )
                    );
                else
                {
                    result = db.ExecuteQuery(
                    string.Format(
                        @"EXECUTE dbo.users_update {0}, N'{1}', '{2}', N'{3}', N'{4}', N'{5}', {6}, {7};",
                        this.id,
                        this.name,
                        this.passwd,
                        this.realName,
                        this.email,
                        this.additionalContacts.ToString(),
                        this.roleId,
                        this.groupId
                        )
                    );
                }
                if (result.Rows.Count < 1)
                    return null;
                return new User(
                        this.db,
                        (int)result.Rows[0]["id"],
                        (string)result.Rows[0]["name"],
                        (string)result.Rows[0]["passwd"],
                        (string)result.Rows[0]["real_name"],
                        (string)result.Rows[0]["email"],
                        !result.Rows[0].IsNull("additional_contacts") ? new AdditionalContacts((string)result.Rows[0]["additional_contacts"]) : new AdditionalContacts(),
                        !result.Rows[0].IsNull("last_login_date") ? ((DateTime)result.Rows[0]["last_login_date"]).ToString() : null,
                        ((DateTime)result.Rows[0]["registration_date"]).ToString(),
                        !result.Rows[0].IsNull("last_edit_date") ? ((DateTime)result.Rows[0]["last_edit_date"]).ToString() : null,
                        (int)result.Rows[0]["role_id"],
                        (int)result.Rows[0]["group_id"]);
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
        public User ChangePassword(string passwd)
        {
            DataTable result = db.ExecuteQuery(String.Format(@"EXECUTE dbo.users_change_passwd {0}, {1}", this.id, passwd));
            if (result.Rows.Count < 1)
                return null;
            return new User(
                this.db,
                this.id,
                this.name,
                (string)result.Rows[0]["PASSWD"],
                this.realName,
                this.email,
                this.additionalContacts,
                this.lastLoginDate,
                this.registrationDate,
                this.lastEditDate,
                this.roleId,
                this.groupId);
        }
        public User Get(int id)
        {
            DataTable result = db.ExecuteQuery(String.Format(@"SELECT * FROM users WHERE id = {0}", id));
            if (result.Rows.Count < 1)
                return null;
            return new User(
                this.db,
                (int)result.Rows[0]["id"],
                (string)result.Rows[0]["name"],
                (string)result.Rows[0]["passwd"],
                (string)result.Rows[0]["real_name"],
                (string)result.Rows[0]["email"],
                !result.Rows[0].IsNull("additional_contacts") ? new AdditionalContacts((string)result.Rows[0]["additional_contacts"]) : new AdditionalContacts(),
                !result.Rows[0].IsNull("last_login_date") ? ((DateTime)result.Rows[0]["last_login_date"]).ToString() : null,
                ((DateTime)result.Rows[0]["registration_date"]).ToString(),
                !result.Rows[0].IsNull("last_edit_date") ? ((DateTime)result.Rows[0]["last_edit_date"]).ToString() : null,
                (int)result.Rows[0]["role_id"],
                !result.Rows[0].IsNull("group_id") ? (int)result.Rows[0]["group_id"] : -1
                );
        }
        public void AddContact(string service, string contact)
        {
            this.additionalContacts.Add(service, contact);
        }
        public void Delete()
        {
            try
            {
                db.ExecuteNonQuery(String.Format(@"DELETE FROM users WHERE id = {0}", this.id));
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
        //Added by Lesya
        public void DeleteByID(int id)
        {
            try
            {
                db.ExecuteNonQuery(String.Format(@"DELETE FROM users WHERE id = {0}", id));
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

        static public DataTable GetUsersDataTable(DBDriver db)
        {
            return db.ExecuteQuery(String.Format(@"SELECT * FROM users"));
        }

        static public DataTable GetTutorsDataTable(DBDriver db)
        {
            //return db.ExecuteQuery(String.Format(@"SELECT users.id, users.real_name, users.name, users.passwd, users.email, users.additional_contats, users.last_login_date, users.registration_date, users.last_edit_date, groups.name as 'group_name' FROM users, groups WHERE users.role_id = 2"));
            return db.ExecuteQuery(String.Format(@"SELECT users.id, users.real_name, users.name, users.passwd, users.email, users.additional_contacts, users.last_login_date, users.registration_date, users.last_edit_date, users.group_id FROM users WHERE users.role_id = 2"));
        }
        


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(String.Format("{0}:{1};\n", "id", this.id));
            builder.Append(String.Format("{0}:{1};\n", "name", this.name));
            builder.Append(String.Format("{0}:{1};\n", "passwd", this.passwd));
            builder.Append(String.Format("{0}:{1};\n", "real_name", this.realName));
            builder.Append(String.Format("{0}:{1};\n", "email", this.email));
            builder.Append(String.Format("{0}:{1};\n", "additional_contacts", this.additionalContacts));
            builder.Append(String.Format("{0}:{1};\n", "last_login_date", this.lastLoginDate));
            builder.Append(String.Format("{0}:{1};\n", "registration_date", this.registrationDate));
            builder.Append(String.Format("{0}:{1};\n", "last_edit_date", this.LastEditDate));
            builder.Append(String.Format("{0}:{1};\n", "role_id", this.roleId));
            builder.Append(String.Format("{0}:{1};\n", "group_id", this.groupId));
            return builder.ToString();
        }
    }


}
