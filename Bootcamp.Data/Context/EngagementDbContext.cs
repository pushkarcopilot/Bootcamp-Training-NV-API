using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Context
{
    public class EngagementDbContext : DbContext
    {
        public EngagementDbContext(DbContextOptions<EngagementDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Engagement>()
                .Property(e => e.AuditTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<Engagement>()
                .Property(e => e.StatusId)
                .HasConversion<int>();

        }

        public DbSet<Engagement> Engagements { get; set; }
        //public DbSet<EngagementSetting> EngagementSettings { get; set; }
        //public DbSet<EngagementBackup> EngagementBackups { get; set; }
    }
}
