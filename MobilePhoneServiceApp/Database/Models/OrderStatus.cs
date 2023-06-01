using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("STATUSY_ZLECENIA")]
    public class OrderStatus
    {
        [Key]
        [Column("ID_STATUSU")]
        public int ID { get; set; }

        [Column("NAZWA_STATUSU")]
        public string StatusName { get; set; }
    }
}
