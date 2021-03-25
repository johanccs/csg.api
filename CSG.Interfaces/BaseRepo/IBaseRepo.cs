using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSG.Interfaces.BaseRepo
{
    public interface IBaseRepo<TEntity, TTYPE> where TEntity:class
    {
        List<TEntity> GetAllAsync();
        void InsertEntityAsync(TEntity entity);
        void DeleteByIdAsync(TTYPE entityId);        
        void DeleteAllAsync();
    }
}
