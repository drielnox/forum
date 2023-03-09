
using drielnox.forum.Persistence.Abstractions;
using Entities;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork<ForumContext>
    {
        private readonly ForumContext _context;

        public bool CanConnect => _context.Database.CanConnect();

        public IRepository<Forum> Forums => new ForumRepository(_context);

        public UnitOfWork()
        {
            _context = new ForumContext();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
