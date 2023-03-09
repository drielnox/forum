using Microsoft.EntityFrameworkCore;
using System;

namespace drielnox.forum.Persistence.Abstractions
{
    public interface IUnitOfWork<TDbContext> : IDisposable
        where TDbContext : DbContext
    {
        void Save();
    }
}
