using System;

namespace drielnox.Forum.Business.Logic.DTOs.Requests
{
    public sealed class CreateForumRequest
    {
        public string Name { get; }
        public string UserId { get; }
        public string Email { get; }

        public CreateForumRequest(string name, string userId, string email)
        {
            Name = name;
            UserId = userId;
            Email = email;
        }
    }
}
