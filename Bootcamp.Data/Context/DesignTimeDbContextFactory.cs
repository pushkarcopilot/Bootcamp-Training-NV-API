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
                        "Server=PUDHANASHRIJADH;Database=LevviaBootcamp2;Trusted_Connection=true;TrustServerCertificate=true",
                        x => x.MigrationsAssembly("Bootcamp.Migrations"));

        return new EngagementDbContext(optionsBuilder.Options);
    }
}
