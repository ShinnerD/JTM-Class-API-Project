using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
  public class CustomerContext : DbContext
  {
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
      optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
    }
  }
}