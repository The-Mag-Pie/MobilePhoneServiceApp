using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database
{
    [Table("ZLECENIA")]
    public class RepairOrder
    {
        [Key]
        [Column("ID_ZLECENIA")]
        public int ID { get; set; }

        [Column("OPIS_SZKODY")]
        public string DamageDescription { get; set; }

        [Column("STATUSY_ZLECENIA_ID_STATUSU")]
        public int OrderStatusID { get; set; }

        [Column("ADRESY_DO_PRZESYLEK_ID_ADRESU")]
        public int? ShippingAddressID { get; set; }

        [Column("KLIENCI_ID_KLIENTA")]
        public int ClientID { get; set; }

        [Column("TELEFONY_ID_TELEFONU")]
        public int PhoneID { get; set; }

        [Column("PRACOWNICY_ID_SERWISANTA")]
        public int? RepairEmployeeID { get; set; }

        [Column("PRACOWNICY_ID_OBSLUGAKLIENTA")]
        public int? CustomerServiceEmployeeID { get; set; }
    }

    [Table("TELEFONY")]
    public class Phone
    {
        [Key]
        [Column("ID_TELEFONU")]
        public int ID { get; set; }

        [Column("MARKA")]
        public string Brand { get; set; }

        [Column("MODEL")]
        public string Model { get; set; }

        [Column("IMEI")]
        public string IMEI { get; set; }

        [Column("ZDJECIA_URL")]
        public string? PhotosURL { get; set; }
    }

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
    }
}
