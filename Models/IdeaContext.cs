using Microsoft.EntityFrameworkCore;

namespace blueSwash.Models
{
    public class IdeaContext : DbContext
    {
        public IdeaContext(DbContextOptions<IdeaContext> options) : base(options) {}
        public DbSet<Users> users {get; set;}
        public DbSet<Ideas> ideas {get; set;}
        public DbSet<LikedIdeas> likedideas {get; set;}
    }
}