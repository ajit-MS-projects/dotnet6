using System;
using System.Collections.Generic;

namespace EntityCoreDbFirst.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}
