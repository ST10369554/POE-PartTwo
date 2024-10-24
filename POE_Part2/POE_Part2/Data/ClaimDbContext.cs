using POE_Part2.Models;
using Microsoft.EntityFrameworkCore;

namespace POE_Part2.Data
{
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext(DbContextOptions<ClaimDbContext> options) : base(options) 
        { 
        }
        public DbSet<LecturerClaim> Claims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
