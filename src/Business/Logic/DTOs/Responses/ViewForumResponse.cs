using System;

namespace drielnox.Forum.Business.Logic.DTOs.Responses
{
    public sealed class ViewForumResponse
    {
        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Administrator { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
