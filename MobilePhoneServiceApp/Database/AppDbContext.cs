using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MobilePhoneServiceApp.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Client> Clients { get; set; }

        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = ConfigurationManager.ConnectionStrings["oracleConnectionString"].ConnectionString;
            optionsBuilder.UseOracle(connectionString);
        }
    }
}
