using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<DocumentDetails>(entity =>
            {
                entity.ToTable("DocumentDetails");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UploadedAt)
                    .IsRequired();

                entity.Property(e => e.DataContentVarbinary)
                    .IsRequired();
            });
        }
        public DbSet<DocumentDetails> FileRecords { get; set; }

        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<EngagementSetting> EngagementSettings { get; set; }
        public DbSet<EngagementBackup> EngagementBackups { get; set; }
    }
}
