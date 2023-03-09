﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public class Forum
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
    }
}