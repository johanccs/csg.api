using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSG.Interfaces.BaseRepo
{
    public interface IBaseRepo<TEntity, TTYPE> where TEntity:class
    {
        Task<List<TEntity>> GetAllAsync();
        Task InsertEntityAsync(TEntity entity);
        Task DeleteByIdAsync(TTYPE entityId);        
        Task DeleteAllAsync();
    }
}
