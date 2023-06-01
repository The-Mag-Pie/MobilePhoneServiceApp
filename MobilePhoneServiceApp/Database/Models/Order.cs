using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("ZLECENIA")]
    public class Order
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
}
