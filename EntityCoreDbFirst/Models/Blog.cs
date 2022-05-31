using System;
using System.Collections.Generic;

namespace EntityCoreDbFirst.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
            Posts2s = new HashSet<Posts2>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; } = null!;
        public int Rating { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Posts2> Posts2s { get; set; }
    }
}
