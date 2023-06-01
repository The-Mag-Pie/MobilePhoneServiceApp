using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("ADRESY_DO_PRZESYLEK")]
    public class DeliveryAddress
    {
        [Key]
        [Column("ID_ADRESU")]
        public int ID { get; set; }

        [Column("KRAJ")]
        public string Country { get; set; }

        [Column("MIASTO")]
        public string City { get; set; }

        [Column("KOD_POCZTOWY")]
        public string PostCode { get; set; }

        [Column("ULICA")]
        public string Street { get; set; }

        [Column("NR_DOMU")]
        public string HouseNumber { get; set; }

        [Column("NR_MIESZKANIA")]
        public int? ApartmentNumber { get; set; }
    }
}
