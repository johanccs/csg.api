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
    public class ClassRepo:BaseRepo,IBaseRepo<ClassEntity,string>
    {
        #region Readonly Fields

        private readonly SQLConnType _dbContext;

        #endregion

        #region Constructor

        public ClassRepo(SQLConnType dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public List<ClassEntity> GetAllAsync()
        {
            var results =  _dbContext.ExecuteQuery(SP_GETCLASS);

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

        public void InsertEntityAsync(ClassEntity entity)
        {
            try
            {
                var paramList = BuildSqlParameters(entity);
               
                 _dbContext.ExecuteNonQuery(SP_INSERTCLASS, paramList);
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
                var results = _dbContext.ExecuteNonQuery(SP_DELETEALLCLASSES);
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
                var paramList = BuildIdSqlParameterList<string>("@classId", entityId);
                var results = _dbContext.ExecuteNonQuery(SP_DELETECLASSEBYID, paramList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<ClassEntity> BuildResultSet(DataTable dt)
        {
            var classes = new List<ClassEntity>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var classEntity = new ClassEntity(row[CLASSID].ToString());                   
                    classEntity.ClassName = row[CLASSNAME].ToString();
                    classEntity.Description = row[DESCRIPTION].ToString();
                    
                    classes.Add(classEntity);
                    classEntity = null;
                }
            }

            return classes;
        }

        private List<SqlParameter> BuildSqlParameters(ClassEntity entity)
        {
            var paramList = new List<SqlParameter>()
            {
                new SqlParameter("@classId", entity.Id),
                new SqlParameter("@className", entity.ClassName),
                new SqlParameter("@description", entity.Description)                
            };

            return paramList;
        }

        #endregion
    }
}
