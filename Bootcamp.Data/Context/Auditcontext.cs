using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bootcamp.Data.Context
{
    public class Auditcontext:DbContext
    {
        protected readonly IConfiguration configuration;

        public Auditcontext(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<LEV_Engagement> LEV_Engagement { get; set; }
        public DbSet<LEV_AuditStatus> LEV_AuditStatus { get; set; }
        public DbSet<LEV_Auditors> LEV_Auditors { get; set; }
        public DbSet<LEV_Countries> LEV_Countries { get; set; }
        public DbSet<LEV_AuditTypes> LEV_AuditTypes { get; set; }

        public DbSet<LEV_Account> LEV_Accounts { get; set; }
    }
}
