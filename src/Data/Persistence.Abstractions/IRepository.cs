using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drielnox.forum.Persistence.Abstractions
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, ICUDRepository<TEntity>
        where TEntity : class
    {
    }
}
