using ST10369554_PROG6212_POE.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ST10369554_PROG6212_POE.Data
{
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext(DbContextOptions<ClaimDbContext> options) : base(options) 
        { 
        }

        public DbSet<Claim> Claims { get; set; }

       /* public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ClaimStatus> ClaimStatuses { get; set; }
        
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }*/
    }
}
