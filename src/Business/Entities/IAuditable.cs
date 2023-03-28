using System;

namespace drielnox.Forum.Business.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime AmendedAt { get; set; }
        string AmendedBy { get; set; }
    }
}
