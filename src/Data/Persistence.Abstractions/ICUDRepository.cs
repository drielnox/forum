using System.Collections.Generic;

namespace drielnox.forum.Persistence.Abstractions
{
    public interface ICUDRepository<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Modify(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
