using MobilePhoneServiceApp.Database.Models;

namespace MobilePhoneServiceApp.Windows
{
    public class ModifyClientWindow : AddModifyClientWindowBase
    {
        public ModifyClientWindow(Client client) : base(new()
        {
            ID = client.ID,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Country = client.Country,
            City = client.City,
            Street = client.Street,
            HouseNumber = client.HouseNumber,
            ApartmentNumber = client.ApartmentNumber,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber
        })
        {
            Title = "Modyfikacja klienta";
        }
    }
}
