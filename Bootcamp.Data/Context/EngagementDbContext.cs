using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Context
{
    internal class EngagementDbContext : DbContext
    {
        public EngagementDbContext() : base()
        {
            //var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
            //databaseCreator.CreateTables();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To Display the Generated the Database Script
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            //Configuring the Connection String
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bootcamp3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=true");
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
                    Enum.GetValues(typeof(AuditTypeId))
                        .Cast<AuditTypeId>()
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

        public DbSet<Engagement> Engagements { get; set; }
        //public DbSet<EngagementSetting> EngagementSettings { get; set; }
        //public DbSet<EngagementBackup> EngagementBackups { get; set; }
    }
}
