using CommunityToolkit.Mvvm.ComponentModel;
using MobilePhoneServiceApp.Database;

namespace MobilePhoneServiceApp.ViewModels
{
    public class ClientsViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        public ClientsViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
