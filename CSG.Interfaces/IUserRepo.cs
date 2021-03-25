using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSG.Interfaces
{
    public interface IUserRepo<TEntity, TTYPE> where TEntity : class
    {
        List<TEntity> GetAllAsync();
        void InsertEntityAsync(TEntity entity);
    }
}
