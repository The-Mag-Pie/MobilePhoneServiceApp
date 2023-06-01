using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("PRACOWNICY")]
    public class Employee
    {
        [Key]
        [Column("ID_PRACOWNIKA")]
        public int ID { get; set; }

        [Column("IMIE")]
        public string FirstName { get; set; }

        [Column("DRUGIE_IMIE")]
        public string? SecondName { get; set; }

        [Column("NAZWISKO")]
        public string LastName { get; set; }

        [Column("PODSTAWOWA_PENSJA")]
        public int BaseSalary { get; set; }

        [Column("DZIALY_ID_DZIALU")]
        public int DepartmentID { get; set; }
    }
}
