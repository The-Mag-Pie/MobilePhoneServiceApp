using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using System.Text.RegularExpressions;
using System.Windows;

namespace MobilePhoneServiceApp.ViewModels
{
    public class AddModifyOrderViewModel
    {
        private readonly Order _order;
        private readonly AppDbContext _dbContext;

        public Order Order => _order;

        public AddModifyOrderViewModel(Order order)
        {
            _order = order;
            _dbContext = ServiceHelper.GetService<AppDbContext>();
        }

        public bool ValidateData()
        {
            var damageDescription = Order.DamageDescription;
            var statusID = Order.OrderStatusID;
            var clientID = Order.ClientID;
            var phoneID = Order.PhoneID;

            var messageText = string.Empty;

            if (damageDescription is null || damageDescription == string.Empty)
            {
                messageText += "Opis szkody nie może być pusty!\n";
            }

            if (messageText != string.Empty)
            {
                MessageBox.Show(messageText, "Błędne dane");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
