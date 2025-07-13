using AngularApp1.Server.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Context
{
    public class BlogDbContext :DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }

    }
}
