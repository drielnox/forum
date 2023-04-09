using System.Collections.Generic;

namespace drielnox.Forum.Business.Entities
{
    public sealed class Category
    {
        public int Identifier { get; set; }
        public string Name { get; set; }

        public ICollection<Discussion> RelatedDiscussions { get; private set; }

        public Category()
        {
            RelatedDiscussions = new HashSet<Discussion>();
        }
    }
}
