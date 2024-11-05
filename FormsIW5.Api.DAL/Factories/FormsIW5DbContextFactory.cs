using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FormsIW5.Api.DAL.Factories;

public class FormsIW5DbContextFactory : IDesignTimeDbContextFactory<FormsIW5DbContext>
{
    public FormsIW5DbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<FormsIW5DbContextFactory>(optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<FormsIW5DbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        return new FormsIW5DbContext(optionsBuilder.Options);
    }
}


