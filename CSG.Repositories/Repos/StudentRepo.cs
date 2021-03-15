using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSG.Repositories.Repos
{
    public class StudentRepo : BaseRepo, IBaseRepo<Student>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public StudentRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public List<Student> GetAll()
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

        private List<Student> BuildResultSet(DataTable dt)
        {
            var students = new List<Student>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var student = new Student();
                    student.Id = row[STUDENTID].ToString();
                    student.Name = row[NAME].ToString();
                    student.Surname = row[SURNAME].ToString();
                    student.DateRegistered = Convert.ToDateTime(row[DATEREGISTERED]);

                    students.Add(student);
                    student = null;
                }
            }

            return students;
        }

        #endregion       
    }
}
