using System.Collections.Generic;

namespace CSG.Interfaces.BaseRepo
{
    public interface IBaseRepo<TEntity> where TEntity:class
    {
        List<TEntity> GetAll();
    }
}
