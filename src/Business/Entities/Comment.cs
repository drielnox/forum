using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Comment
    {
        public int DiscussionId { get; set; }
        public Discussion RelatedDiscussion { get; set; }
        public int Identifier { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
