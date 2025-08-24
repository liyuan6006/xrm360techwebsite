using System.Collections.Generic;
using System.Reflection.Emit;
using XRM360website.Models;
using Microsoft.EntityFrameworkCore;

namespace XRM360website.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StudentLead> StudentLeads => Set<StudentLead>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<StudentLead>(e =>
            {
                e.HasIndex(x => x.CreatedUtc);
                e.HasIndex(x => x.Email);
            });
        }
    }
}
