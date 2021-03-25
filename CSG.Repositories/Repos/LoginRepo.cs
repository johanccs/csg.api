using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CSG.Repositories.Repos
{
    public class LoginRepo:BaseRepo, IUserRepo<Login,string>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public LoginRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public List<Login> GetAllAsync()
        {
            var results =  _dbContext.ExecuteQuery(SP_GETLOGINS);

            try
            {
                if (results.IsSuccessfull)
                {
                    return BuildResultSet(results.GetResults());
                }

                throw new Exception(results.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEntityAsync(Login entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);

                 _dbContext.ExecuteNonQuery(SP_INSERTLOGIN, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<Login> BuildResultSet(DataTable dt)
        {
            var logins = new List<Login>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var login = new Login(row[CLASSID].ToString());
                    login.LoginTime = Convert.ToDateTime(row[LOGINTIME]);
                    login.LogOutTime = Convert.ToDateTime(row[LOGOUTTIME]);
                    login.UserId = row[USERID].ToString();

                    logins.Add(login);
                    login = null;
                }
            }

            return logins;
        }

        private List<SqlParameter> BuildSqlParameters(Login entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@userId", entity.Id),
                new SqlParameter("@loginTime", entity.LoginTime),
                new SqlParameter("@logoutTime", entity.LogOutTime),
                new SqlParameter("@userId", entity.UserId)
            };

            return paramList;
        }

        #endregion
    }
}
