using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DBLibrary
{
    public class DBDriver
    {
        private string host;
        private string user;
        private string passwd;
        private string dbname;
        private string connectionString;
        public DBDriver(string host, string user, string passwd, string dbname)
        {
            this.host = host;
            this.user = user;
            this.passwd = passwd;
            this.dbname = dbname;
            this.connectionString = String.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3}", this.host, this.dbname, this.user, this.passwd);
        }
        private SqlConnection Connection 
        {
            get {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(this.connectionString);
                }
                catch (SqlException e)
                {
                    //MessageBox.Show(e.Message);
                    throw e;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    throw e;
                }
                return connection; 
            }
        }
        public string Host
        {
            get { return this.host; }
        }
        public string User
        {
            get { return this.user; }
        }
        public string Passwd
        {
            get { return this.passwd; }
        }
        public string DBName
        {
            get { return this.dbname; }
        }
        public string ConnString
        {
            get { return this.connectionString; }
        }
        public IAsyncResult ExecuteNonQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query);
            SqlConnection connection = this.Connection;
            sqlCommand.Connection = connection;
            AsyncCallback callback = ((IAsyncResult result) =>
            {
                try
                {
                    sqlCommand.EndExecuteNonQuery(result);
                    connection.Close();

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
                    if (connection != null)
                    {
                        if(connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Dispose();
                    }
                }
                
            });
            connection.Open();
            return sqlCommand.BeginExecuteNonQuery(callback, sqlCommand);
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable res = null;
            SqlDataAdapter adapter = null;
            SqlConnection connection = null;

            try
            {
                connection = this.Connection;
                adapter = new SqlDataAdapter(query, connection);
                res = new DataTable();
                adapter.Fill(res);
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
                if (adapter != null)
                    adapter.Dispose();
                if (connection != null)
                    {
                        if(connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
            }
            return res;
        }
    }
}
