using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentoringProgramApplication.DataLayer
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> UserProfiles { get; set; }
        public DbSet<MyImage> Images { get; set; }
    }
}
