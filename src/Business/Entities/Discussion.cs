using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Discussion
    {
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
        public int Identifier { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int CommentsCount => Comments.Count;
        public ISet<Comment> Comments { get; set; }

        public Discussion()
        {
            Comments = new HashSet<Comment>();
        }

        public void AddComment(string content, string commentBy, string email)
        {
            var comment = new Comment()
            {
                DiscussionId = Identifier,
                RelatedDiscussion = this,
                Content = content,
                CreatedBy = commentBy,
                CreatedAt = DateTime.UtcNow,
                Email = email,
            };

            Comments.Add(comment);
        }
    }
}
