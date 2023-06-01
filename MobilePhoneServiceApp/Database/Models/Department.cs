using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneServiceApp.Database.Models
{
    [Table("DZIALY")]
    public class Department
    {
        [Key]
        [Column("ID_DZIALU")]
        public int ID { get; set; }

        [Column("NAZWA_DZIALU")]
        public string DepartmentName { get; set; }
    }
}
