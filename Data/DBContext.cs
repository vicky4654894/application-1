using Microsoft.EntityFrameworkCore;
using _1_Application.Models.Domain;

namespace _1_Application.Data
{
    public class DBContext : DbContext
    {
         public DBContext(DbContextOptions<DBContext> options)
        : base(options)   // <-- THIS must be on the same line with : 
    {
    }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
