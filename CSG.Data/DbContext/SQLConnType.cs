using CSG.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CSG.Data.DbContext
{
    public class SQLConnType
    {
        #region Readonly Fields

        private readonly string _username;
        private readonly string _password;
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

        public SQLConnType()
        {
            _server = @"localhost\SQLEXPRESS14";
            _initDb = "CSG";
            _username = "sa";
            _password = "@1Mops4moa";

            _connectionString = BuildConnectionString();
        }

        public SQLConnType(string server, string initDb, string username, string password)
        {           
            _server = server;
            _initDb = initDb;
            _username = username;
            _password = password;

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
        public async Task<SQLResults> ExecuteQuery(string sqlCmd)
        {
            try
            {
                SQLResults results = null;

                using (Connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand())
                    {
                        var dt = new DataTable();

                        if(Connection.State != ConnectionState.Open)
                            Connection.Open();

                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlCmd;
                        cmd.AddSqlParameters(cmd);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        await Task.Run(() =>
                        {
                            da.Fill(dt);

                            if (HasSPFailed(cmd))
                            {
                                results = new SQLResults(
                                    cmd.Parameters["@errorMessage"].Value.ToString(),
                                    cmd.Parameters["@errorNumber"].Value.ToString(),
                                    cmd.Parameters["@errorSeverity"].Value.ToString(),
                                    cmd.Parameters["@errorState"].Value.ToString(),
                                    cmd.Parameters["@errorProcedure"].Value.ToString(),
                                    cmd.Parameters["@errorLine"].Value.ToString(),
                                    cmd.CommandText
                                );
                            }
                            else
                            {
                                results = new SQLResults(dt);
                            }
                        });
                    }
                }

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SQLResults> ExecuteNonQuery(string sqlCmd)
        {
            try
            {
                SQLResults results = null;

                using (Connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand())
                    {
                        var dt = new DataTable();

                        Connection.Open();
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlCmd;
                        cmd.AddSqlParameters(cmd);

                        var resultCount = 0;

                        await Task.Run(() =>
                        {
                            resultCount = cmd.ExecuteNonQuery();

                            if (HasSPFailed(cmd) && resultCount > 0)
                            {
                                results = new SQLResults(
                                    cmd.Parameters["@errorMessage"].Value.ToString(),
                                    cmd.Parameters["@errorNumber"].Value.ToString(),
                                    cmd.Parameters["@errorSeverity"].Value.ToString(),
                                    cmd.Parameters["@errorState"].Value.ToString(),
                                    cmd.Parameters["@errorProcedure"].Value.ToString(),
                                    cmd.Parameters["@errorLine"].Value.ToString(),
                                    cmd.CommandText
                                );
                            }
                            else
                            {
                                results = new SQLResults(resultCount);
                            }
                        });
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SQLResults> ExecuteNonQuery(string sqlCmd, List<SqlParameter>paramList)
        {
            try
            {
                SQLResults results = null;

                using (Connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand())
                    {
                        var dt = new DataTable();
                        
                        Connection.Open();
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlCmd;
                        cmd.AddSqlParameters(cmd);
                        cmd.AddRequiredSqlParameters(cmd, paramList);

                        await Task.Run(() =>
                        {
                            var resultCount = cmd.ExecuteNonQuery();

                            if (HasSPFailed(cmd) && resultCount > 0)
                            {
                                results = new SQLResults(
                                    cmd.Parameters["@errorMessage"].Value.ToString(),
                                    cmd.Parameters["@errorNumber"].Value.ToString(),
                                    cmd.Parameters["@errorSeverity"].Value.ToString(),
                                    cmd.Parameters["@errorState"].Value.ToString(),
                                    cmd.Parameters["@errorProcedure"].Value.ToString(),
                                    cmd.Parameters["@errorLine"].Value.ToString(),
                                    cmd.CommandText
                                );
                            }
                            else
                            {
                                results = new SQLResults(resultCount);
                            }
                        });
                    }
                }
                return results;
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
