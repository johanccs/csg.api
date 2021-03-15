using CSG.Data.Extensions;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CSG.Data.DbContext
{
    public class SQLConnType
    {
        #region Readonly Fields

        private readonly string _username;
        private readonly string _password;
        private readonly string _sqlcmd;
        private readonly string _server;
        private readonly string _initDb;

        #endregion

        #region Fields

        private string _connectionString { get; set; }

        #endregion

        #region Properties

        public SqlConnection Connection { get; set; }

        #endregion


        #region Constructor

        public SQLConnType(string server, string initDb, string username, string password)
        {           
            _server = server;
            _initDb = initDb;
            _username = username;
            _password = password;

            _connectionString = BuildConnectionString();
        }

        public SQLConnType(string server, string initDb, string username, string password, string sqlcmd)
        {            
            _server = server;
            _initDb = initDb;
            _username = username;
            _password = password;
            _sqlcmd = sqlcmd;

            _connectionString = BuildConnectionString();
        }

        #endregion

        #region Methods
       
        public DbConnection Connect()
        {
            try
            {
                Connection.Open();

                return Connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Disconnect()
        {
            if (Connection != null || Connection.State == ConnectionState.Closed)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
        public SQLResults ExecuteQuery()
        {
            try
            {    
                using (Connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand())
                    {
                        var dt = new DataTable();

                        Connection.Open();
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = _sqlcmd;
                        cmd.AddSqlParameters(cmd);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (HasSPFailed(cmd))
                        {
                            var errObj = new SQLResults(
                                cmd.Parameters["@errorMessage"].Value.ToString(),
                                cmd.Parameters["@errorNumber"].Value.ToString(),
                                cmd.Parameters["@errorSeverity"].Value.ToString(),
                                cmd.Parameters["@errorState"].Value.ToString(),
                                cmd.Parameters["@errorProcedure"].Value.ToString(),
                                cmd.Parameters["@errorLine"].Value.ToString(),
                                cmd.CommandText
                            );

                            return errObj;
                        }
                        else
                        {
                           return new SQLResults(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteNonQuery()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(_connectionString);

                    if (Connection.State == ConnectionState.Closed)
                    {
                        Connect();
                    }
                }

                SqlCommand cmd = new SqlCommand(_sqlcmd, (SqlConnection)Connection);

                var resultCount = cmd.ExecuteNonQuery();

                return resultCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private string BuildConnectionString()
        {
            var connBuilder = new StringBuilder();
            connBuilder.AppendLine($"Server={_server}; Database={_initDb};");
            connBuilder.AppendLine($"User Id={_username};");
            connBuilder.AppendLine($"Password={_password};");

            return connBuilder.ToString();
        }

        private bool HasSPFailed(SqlCommand cmd)
        {
            if (cmd.Parameters.Count == 0)
                return false;

            if(!string.IsNullOrEmpty(cmd.Parameters["@errorMessage"].Value.ToString()) && 
                Convert.ToInt32(cmd.Parameters["@errorNumber"].Value) > 0)
            {
                return true;
            }

            return false;
        }

      

        #endregion
    }
}
