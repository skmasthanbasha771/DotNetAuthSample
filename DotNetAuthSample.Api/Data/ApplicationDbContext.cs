using DotNetAuthSample.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAuthSample.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
