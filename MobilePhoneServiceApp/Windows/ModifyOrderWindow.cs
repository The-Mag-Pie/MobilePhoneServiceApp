using MobilePhoneServiceApp.Database.Models;

namespace MobilePhoneServiceApp.Windows
{
    public class ModifyOrderWindow : AddModifyOrderWindowBase
    {
        public ModifyOrderWindow(Order order) : base(new()
        {
            ID = order.ID,
            DamageDescription = order.DamageDescription,
            OrderStatusID = order.OrderStatusID,
            ShippingAddressID = order.ShippingAddressID,
            ClientID = order.ClientID,
            PhoneID = order.PhoneID,
            RepairEmployeeID = order.RepairEmployeeID,
            CustomerServiceEmployeeID = order.CustomerServiceEmployeeID
        })
        {
            Title = "Modyfikacja zlecenia";
        }
    }
}
