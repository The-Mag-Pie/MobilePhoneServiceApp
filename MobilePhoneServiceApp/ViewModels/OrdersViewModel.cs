using CommunityToolkit.Mvvm.ComponentModel;
using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using System.Collections.ObjectModel;

namespace MobilePhoneServiceApp.ViewModels
{
    public class OrdersViewModel : ObservableObject
    {
        public ObservableCollection<Order> Orders { get; set; } = new();

        private readonly AppDbContext _dbContext;

        public OrdersViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            foreach (var item in dbContext.Orders)
                Orders.Add(item);
        }
    }
}
