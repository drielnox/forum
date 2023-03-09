using drielnox.forum.Persistence.Abstractions;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class ForumRepository : IRepository<Forum>
    {
        private readonly ForumContext _unitOfWork;

        public ForumRepository(ForumContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Forum Add(Forum entity)
        {
            var result = _unitOfWork.Forums.Add(entity);
            return result.Entity;
        }

        public void AddRange(IEnumerable<Forum> entities)
        {
            _unitOfWork.Forums.AddRange(entities);
        }

        public Forum Delete(Forum entity)
        {
            var result = _unitOfWork.Forums.Remove(entity);
            return result.Entity;
        }

        public Forum Get(int id)
        {
            return _unitOfWork.Forums.Find(id);
        }

        public ISet<Forum> GetAll()
        {
            return _unitOfWork.Forums.ToHashSet();
        }

        public Forum Modify(Forum entity)
        {
            var result = _unitOfWork.Forums.Update(entity);
            return result.Entity;
        }
    }
}
