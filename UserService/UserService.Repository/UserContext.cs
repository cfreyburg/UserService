using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        DbSet<User> Users { get; set; }
    }
}
