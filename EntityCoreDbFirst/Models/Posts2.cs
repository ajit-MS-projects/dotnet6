using System;
using System.Collections.Generic;

namespace EntityCoreDbFirst.Models
{
    public partial class Posts2
    {
        public int Post2Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}
