using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CSG.Repositories.Repos
{
    public class TeacherRepo : BaseRepo, IBaseRepo<Teacher,string>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public TeacherRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public List<Teacher> GetAllAsync()
        {
            try
            {
                var results =  _dbContext.ExecuteQuery(SP_GETTEACHER);

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

        public void InsertEntityAsync(Teacher entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);
                var results =  _dbContext.ExecuteNonQuery(SP_INSERTTEACHER, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAllAsync()
        {
            try
            {
                var results =  _dbContext.ExecuteNonQuery(SP_DELETEALLTEACHERS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteByIdAsync(string entityId)
        {
            try
            {
                var paramList = BuildIdSqlParameterList("@teacherId", entityId);
                var results = _dbContext.ExecuteNonQuery(SP_DELETETEACHERBYID, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<Teacher> BuildResultSet(DataTable dt)
        {
            var teachers = new List<Teacher>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var teacher = new Teacher(row[TEACHERID].ToString());                  
                    teacher.Name = row[NAME].ToString();
                    teacher.Surname = row[SURNAME].ToString();
                    teacher.DateRegistered = Convert.ToDateTime(row[DATEREGISTERED]);

                    teachers.Add(teacher);
                    teacher = null;
                }
            }

            return teachers;
        }

        private List<SqlParameter>BuildSqlParameters(Teacher entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@teacherId", entity.Id),
                new SqlParameter("@name", entity.Name),
                new SqlParameter("@surname", entity.Surname),
                new SqlParameter("@dateRegistered", entity.DateRegistered)
            };

            return paramList;
        }

        #endregion
    }
}

