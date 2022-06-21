using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
  public class MySqlContext : DbContext
  {
    public IConfiguration Configuration { get; }

    public DbSet<Product> Products { get; set; }

    public MySqlContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      // var connectionString = Configuration.GetConnectionString("WebApiDatabase");
      var connectionString = Configuration["ConnectionStrings:WebApiDatabaseJay"];
      var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
      options.UseMySql(connectionString, serverVersion)
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors();
    }

  }
}
