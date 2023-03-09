using System.Collections.Generic;

namespace drielnox.forum.Persistence.Abstractions
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        ISet<TEntity> GetAll();
    }
}
