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
    public class RegistrationRepo : BaseRepo, IBaseRepo<Registration,string>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public RegistrationRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<Registration>> GetAllAsync()
        {
            var results = await _dbContext.ExecuteQuery(SP_GETREGISTRATIONS);

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

        public async Task InsertEntityAsync(Registration entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);
                var results = await _dbContext.ExecuteNonQuery(SP_INSERTREGISTRATIONS, paramList);
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
                var results = await _dbContext.ExecuteNonQuery(SP_DELETEALLREGISTRATIONS);
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
                var paramList = BuildIdSqlParameterList("@regId", entityId);
                var results = await _dbContext.ExecuteNonQuery(SP_DELETECLASSEBYID, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<Registration> BuildResultSet(DataTable dt)
        {
            var registrations = new List<Registration>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var registration = new Registration(row[REGID].ToString());
                   
                    registration.AttendanceDate = Convert.ToDateTime(row[ATTENDANCEDATE]);
                    registration.AttendanceStatusId = Convert.ToInt32(row[ATTENDANCESTATUSID]);
                    registration.ClassId = row[CLASSID].ToString();
                    registration.Grade = Convert.ToDecimal(row[GRADE]);
                    registration.StudentId = row[STUDENTID].ToString();
                    registration.TeacherId = row[TEACHERID].ToString();

                    registrations.Add(registration);
                    registration = null;
                }
            }

            return registrations;
        }

        private List<SqlParameter> BuildSqlParameters(Registration entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@regId", entity.Id),
                new SqlParameter("@classId", entity.ClassId),
                new SqlParameter("@teacherId", entity.TeacherId),
                new SqlParameter("@studentId", entity.StudentId),
                new SqlParameter("@attendanceStatusId", entity.AttendanceStatusId),
                new SqlParameter("@grade", entity.Grade),
                new SqlParameter("@attendanceDate", entity.AttendanceDate)
            };

            return paramList;
        }

        #endregion
    }
}

