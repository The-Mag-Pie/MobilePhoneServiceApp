using Microsoft.EntityFrameworkCore;
using MobilePhoneServiceApp.Database.Models;
using System.Configuration;

namespace MobilePhoneServiceApp.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }

        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = ConfigurationManager.ConnectionStrings["oracleConnectionString"].ConnectionString;
            optionsBuilder.UseOracle(connectionString);
        }
    }
}
