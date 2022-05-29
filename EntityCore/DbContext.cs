using System.Collections.Generic;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Post2> Posts2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=ajitpi1;Database=Blogging;Trusted_Connection=False");
            optionsBuilder.UseSqlServer(@"Data Source=ajitpi1;Persist Security Info=True;User ID=sa;Password=mypassword;Database=Blogging1;");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Post2
    {
        public int Post2Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}