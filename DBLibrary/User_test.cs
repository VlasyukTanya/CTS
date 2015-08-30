using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;

namespace DBLibrary
{
    [DataContract]
    public class User_test
    {
        DBDriver db;
        int id_user;
        int id_test;
        int numberOfTries;
        float mark;
        //допущен ли юзер к экзамену
        bool ifAvailable;
        DateTime testTime;
        bool canSkip;
        bool canBack;
        int testContinuesTime;

        [DataMember]
        public int Id_user
        {
            get { return this.id_user; }
            set { this.id_user = value; }
        }

        [DataMember]
        public int Id_test
        {
            get { return this.id_test; }
            set { this.id_test = value; }
        }

        [DataMember]
        public int NumberOfTries
        {
            get { return this.numberOfTries; }
            set { this.numberOfTries = value; }
        }

        [DataMember]
        public float Mark
        {
            get { return this.mark; }
            set { this.mark = value; }
        }

        [DataMember]
        public bool IfAvailable
        {
            get { return this.ifAvailable; }
            set { this.ifAvailable = value; }
        }

        [DataMember]
        public DateTime TestTime
        {
            get { return this.testTime; }
            set { this.testTime = value; }
        }

        [DataMember]
        public int TestContinuesTime
        {
            get { return this.testContinuesTime; }
            set { this.testContinuesTime = value; }
        }
        
        public User_test(DBDriver db)
        {
            this.db = db;
        }

        public User_test(DBDriver db, int id_user, int id_test, int numberOfTries, float mark, bool ifAvailable, DateTime testTime, bool canSkip, bool canBack, int testContinuesTime)
        {
            this.db = db;
            this.id_user = id_user;
            this.id_test = id_test;
            this.numberOfTries = numberOfTries;
            this.mark = mark;
            this.ifAvailable = ifAvailable;
            this.testTime = testTime;
            this.canSkip = canSkip;
            this.canBack = canBack;
            this.testContinuesTime = testContinuesTime;    
        }

        public void Create()
        {
            this.db.ExecuteNonQuery(String.Format("EXECUTE InsertOfUsers_tests {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", this.id_user, this.id_test, this.numberOfTries, this.mark, this.ifAvailable, this.testTime, this.testContinuesTime));
        }
    }
}
