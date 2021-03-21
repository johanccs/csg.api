using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSG.Interfaces
{
    public interface IUserRepo<TEntity, TTYPE> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task InsertEntityAsync(TEntity entity);
    }
}
