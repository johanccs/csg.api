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
    public class StudentRepo : BaseRepo, IBaseRepo<Student,string>
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

        public async Task<List<Student>> GetAllAsync()
        {
            var results = await _dbContext.ExecuteQuery(SP_GETSTUDENTS);

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
     
        public async Task InsertEntityAsync(Student entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);
                var results = await _dbContext.ExecuteNonQuery(SP_INSERTSTUDENT, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                var results = await _dbContext.ExecuteNonQuery(SP_DELETEALLSTUDENTS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteByIdAsync(string entityId)
        {
            try
            {
                var paramList = BuildIdSqlParameterList("@studentId", entityId);
                var results = await _dbContext.ExecuteNonQuery(SP_DELETESTUDENTBYID, paramList);
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
                    var student = new Student(row[STUDENTID].ToString());
                    
                    student.Name = row[NAME].ToString();
                    student.Surname = row[SURNAME].ToString();
                    student.DateRegistered = Convert.ToDateTime(row[DATEREGISTERED]);

                    students.Add(student);
                    student = null;
                }
            }

            return students;
        }

        private List<SqlParameter> BuildSqlParameters(Student entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@studentId", entity.Id),
                new SqlParameter("@name", entity.Name),
                new SqlParameter("@surname", entity.Surname),
                new SqlParameter("@dateRegistered", entity.DateRegistered)
            };

            return paramList;
        }

        #endregion       
    }
}