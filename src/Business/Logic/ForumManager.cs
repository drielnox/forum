using AutoMapper.QueryableExtensions;
using drielnox.Forum.Business.Entities;
using drielnox.Forum.Business.Logic.DTOs.Requests;
using drielnox.Forum.Business.Logic.DTOs.Responses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace drielnox.Forum.Business.Logic
{
    public sealed class ForumManager : BaseManager, IForumManager
    {
        public IEnumerable<ViewForumResponse> ViewForums()
        {
            using (var ctx = new ForumContext())
            {
                var _forums = ctx.Forums
                    .AsNoTracking()
                    .ProjectTo<ViewForumResponse>(_mapperConfiguration)
                    .ToList();

                return _forums;
            }
        }

        public void CreateForum(CreateForumRequest request)
        {
            using (var ctx = new ForumContext())
            {
                var userStore = new UserStore<User>();
                var userManager = new UserManager<User>(userStore);

                var user = userManager.FindById(request.UserId);

                var newForum = new Entities.Forum()
                {
                    Name = request.Name,
                    Administrator = user.UserName,
                    Email = request.Email,
                };

                ctx.Forums.Add(newForum);

                ctx.SaveChanges();
            }
        }
    }
}
