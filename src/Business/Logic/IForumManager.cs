using drielnox.Forum.Business.Logic.DTOs.Requests;
using drielnox.Forum.Business.Logic.DTOs.Responses;
using System.Collections.Generic;

namespace drielnox.Forum.Business.Logic
{
    public interface IForumManager
    {
        IEnumerable<ViewForumResponse> ViewForums();
        void CreateForum(CreateForumRequest request);
    }
}