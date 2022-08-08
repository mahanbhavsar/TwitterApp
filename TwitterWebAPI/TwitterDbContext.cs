using Microsoft.EntityFrameworkCore;
using TwitterWebAPI.Models;

namespace TwitterWebAPI
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
