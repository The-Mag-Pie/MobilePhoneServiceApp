using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("KLIENCI")]
    public class Client
    {
        [Key]
        [Column("ID_KLIENTA")]
        public int ID { get; set; }

        [Column("IMIE")]
        public string FirstName { get; set; }

        [Column("NAZWISKO")]
        public string LastName { get; set; }

        [Column("KRAJ_ZAMIESZKANIA")]
        public string Country { get; set; }

        [Column("MIASTO_ZAMIESZKANIA")]
        public string City { get; set; }

        [Column("ULICA_ZAMIESZKANIA")]
        public string Street { get; set; }

        [Column("NR_DOMU")]
        public string HouseNumber { get; set; }

        [Column("NR_MIESZKANIA")]
        public int? ApartmentNumber { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("NR_TELEFONU")]
        public string PhoneNumber { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
