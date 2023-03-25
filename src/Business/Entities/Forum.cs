using System;
using System.Collections.Generic;

namespace Entities
{
    public sealed class Forum
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public string Administrator { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime AmendedAt { get; set; }
        public string AmendedBy { get; set; }
        public ISet<Discussion> Discussions { get; set; }

        public Forum()
        {
            Discussions = new HashSet<Discussion>();
        }

        public void AddDiscussion(Category category, string subject, string content, string postedBy)
        {
            var discussion = new Discussion()
            {
                Forum = this,
                ForumId = Identifier,
                Subject = subject,
                Content = content,
                Category = category,
                CategoryId = category.Identifier,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = postedBy,
                ViewCount = 0
            };

            Discussions.Add(discussion);
        }
    }
}
