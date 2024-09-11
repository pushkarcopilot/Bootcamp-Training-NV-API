using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Context
{
    public class EngagementDbContext : DbContext
    {
        public EngagementDbContext(DbContextOptions<EngagementDbContext> options)
        : base(options)
        {
            //var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
            //databaseCreator.CreateTables();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Engagement>()
                .Property(e => e.AuditTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<AuditType>()
                .Property(e => e.AuditTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<Engagement>()
                .Property(e => e.StatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<EngagementStatus>()
                .Property(e => e.EngagementStatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<AuditType>().HasData(
                    Enum.GetValues(typeof(AuditTypeValue))
                        .Cast<AuditTypeValue>()
                        .Select(e => new AuditType()
                        {
                            AuditTypeId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder
                .Entity<EngagementStatus>().HasData(
                    Enum.GetValues(typeof(EngagementStatusId))
                        .Cast<EngagementStatusId>()
                        .Select(e => new EngagementStatus()
                        {
                            EngagementStatusId = e,
                            Name = e.ToString()
                        })
                );
        }
        public DbSet<DocumentDetails> FileRecords { get; set; }

        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<EngagementSetting> EngagementSettings { get; set; }
        public DbSet<EngagementBackup> EngagementBackups { get; set; }


        #region Auth and regiester Access
        public DbSet<Users> UserList { get; set; }
        public DbSet<AuthUser> AuthUser { get; set; }
        #endregion
    }
}
