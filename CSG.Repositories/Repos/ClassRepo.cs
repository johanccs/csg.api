using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSG.Repositories.Repos
{
    public class ClassRepo:BaseRepo,IBaseRepo<ClassEntity>
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

        public List<ClassEntity> GetAll()
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

        private List<ClassEntity> BuildResultSet(DataTable dt)
        {
            var classes = new List<ClassEntity>();

            if (!dt.HasErrors && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var classEntity = new ClassEntity();
                    classEntity.Id = row[CLASSID].ToString();
                    classEntity.ClassName = row[CLASSNAME].ToString();
                    classEntity.Description = row[DESCRIPTION].ToString();
                    
                    classes.Add(classEntity);
                    classEntity = null;
                }
            }

            return classes;
        }

        #endregion       
    }
}
