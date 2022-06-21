using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MySqlContext() { }
        //public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }


        public MySqlContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Product> Products { get; set; }




    }
}
