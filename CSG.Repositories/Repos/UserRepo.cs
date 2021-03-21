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
    public class UserRepo:BaseRepo, IUserRepo<User,string>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public UserRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<User>> GetAllAsync()
        {
            var results = await _dbContext.ExecuteQuery(SP_GETALLUSERS);

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

        public async Task InsertEntityAsync(User entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);

                await _dbContext.ExecuteNonQuery(SP_INSERTUSER, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<User> BuildResultSet(DataTable dt)
        {
            var users = new List<User>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var user = new User(row[CLASSID].ToString());
                    user.Name = row[NAME].ToString();
                    user.Surname = row[SURNAME].ToString();

                    users.Add(user);
                    users = null;
                }
            }

            return users;
        }

        private List<SqlParameter> BuildSqlParameters(User entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@userId", entity.Id),
                new SqlParameter("@name", entity.Name),
                new SqlParameter("@Surname", entity.Surname)
            };

            return paramList;
        }

        #endregion
    }
}
