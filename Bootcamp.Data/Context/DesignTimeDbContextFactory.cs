using Bootcamp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EngagementDbContext>
{
    public EngagementDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EngagementDbContext>();

        // Replace with your connection string
        optionsBuilder.UseSqlServer(
                        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bootcamp3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=true",
                        x => x.MigrationsAssembly("Bootcamp.Migrations"));

        return new EngagementDbContext(optionsBuilder.Options);
    }
}
