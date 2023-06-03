using MobilePhoneServiceApp.Database.Models;

namespace MobilePhoneServiceApp.Windows
{
    public class ModifyAddressWindow : AddModifyAddressWindowBase
    {
        public ModifyAddressWindow(DeliveryAddress address) : base(new()
        {
            ID = address.ID,
            Country = address.Country,
            City = address.City,
            PostCode = address.PostCode,
            Street = address.Street,
            HouseNumber = address.HouseNumber,
            ApartmentNumber = address.ApartmentNumber
        })
        {
            Title = "Modyfikacja adresu do przesyłki";
        }
    }
}
