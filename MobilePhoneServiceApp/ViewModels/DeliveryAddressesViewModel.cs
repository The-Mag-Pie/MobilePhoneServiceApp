using CommunityToolkit.Mvvm.ComponentModel;
using MobilePhoneServiceApp.Database;

namespace MobilePhoneServiceApp.ViewModels
{
    public class DeliveryAddressesViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        public DeliveryAddressesViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
