using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace MobilePhoneServiceApp
{
    [Table("RODZAJE_PLATNOSCI")]
    public class PaymentMethod
    {
        [Key]
        [Column("ID_RODZAJU")]
        public int ID { get; set; }

        [Column("NAZWA")]
        public string Name { get; set; }
    }

    public class TestDbContext : DbContext
    {
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public TestDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = ConfigurationManager.ConnectionStrings["oracleConnectionString"].ConnectionString;
            optionsBuilder.UseOracle(connectionString);
        }
    }
}
