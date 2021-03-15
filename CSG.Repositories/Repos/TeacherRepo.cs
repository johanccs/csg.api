using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CSG.Repositories.Repos
{
    public class TeacherRepo : BaseRepo,IBaseRepo<Teacher>
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

        public List<Teacher> GetAll()
        {
            var results = _dbContext.ExecuteQuery();

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

        #endregion

        #region Private Methods

       private List<Teacher>BuildResultSet(DataTable dt)
        {
            var teachers = new List<Teacher>();

            if(!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    var teacher = new Teacher();
                    teacher.Id = row[TEACHERID].ToString();
                    teacher.Name = row[NAME].ToString();
                    teacher.Surname = row[SURNAME].ToString();
                    teacher.DateRegistered = Convert.ToDateTime(row[DATEREGISTERED]);

                    teachers.Add(teacher);
                    teacher = null;
                }
            }

            return teachers;
        }

        #endregion
    }
}
