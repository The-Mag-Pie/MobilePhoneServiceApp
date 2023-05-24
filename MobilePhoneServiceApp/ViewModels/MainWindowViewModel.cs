using CommunityToolkit.Mvvm.ComponentModel;
using MobilePhoneServiceApp.Database;
using System.Collections.Generic;

namespace MobilePhoneServiceApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public List<string> DatabaseTables => new() { "Zlecenia", "Klienci", "Telefony", "Adresy_do_przesylek" };

        private readonly AppDbContext _dbContext;

        public MainWindowViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
