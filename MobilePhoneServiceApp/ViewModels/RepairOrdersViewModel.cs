using CommunityToolkit.Mvvm.ComponentModel;
using MobilePhoneServiceApp.Database;
using System.Collections.ObjectModel;

namespace MobilePhoneServiceApp.ViewModels
{
    public class RepairOrdersViewModel : ObservableObject
    {
        //public ObservableCollection

        private readonly AppDbContext _dbContext;

        public RepairOrdersViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
