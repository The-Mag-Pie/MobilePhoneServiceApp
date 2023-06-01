using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
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
}
