using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using MobilePhoneServiceApp.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MobilePhoneServiceApp.ViewModels
{
    public partial class ClientsViewModel : ObservableObject
    {
        public ObservableCollection<Client> Clients { get; set; } = new();

        public bool CanBeExecuted => SelectedClient is not null;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
        [NotifyCanExecuteChangedFor(nameof(ModifyCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Client _selectedClient;

        private readonly AppDbContext _dbContext;

        public ClientsViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoadItems();
        }

        private void LoadItems()
        {
            Clients.Clear();
            foreach (var item in _dbContext.Clients.OrderBy(c => c.ID))
            {
                Clients.Add(item);
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void ShowDetails()
        {
            var text = $"ID: {SelectedClient.ID}";
            text += $"\nImię: {SelectedClient.FirstName}";
            text += $"\nNazwisko: {SelectedClient.LastName}";
            text += $"\nKraj zamieszkania: {SelectedClient.Country}";
            text += $"\nMiasto zamieszkania: {SelectedClient.City}";
            text += $"\nUlica zamieszkania: {SelectedClient.Street}";
            text += $"\nNumer domu: {SelectedClient.HouseNumber}";
            text += $"\nNr mieszkania: {SelectedClient.ApartmentNumber}";
            text += $"\nE-mail: {SelectedClient.Email}";
            text += $"\nNumer telefonu: {SelectedClient.PhoneNumber}";

            MessageBox.Show(text, "Szczegóły klienta");
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Modify()
        {
            var modifyWindow = new ModifyClientWindow(SelectedClient);
            modifyWindow.ShowDialog();

            var result = modifyWindow.Result;

            if (result is not null)
            {
                SelectedClient.FirstName = result.FirstName;
                SelectedClient.LastName = result.LastName;
                SelectedClient.Country = result.Country;
                SelectedClient.City = result.City;
                SelectedClient.Street = result.Street;
                SelectedClient.HouseNumber = result.HouseNumber;
                SelectedClient.ApartmentNumber = result.ApartmentNumber;
                SelectedClient.Email = result.Email;
                SelectedClient.PhoneNumber = result.PhoneNumber;

                // SelectedClient is one of tracked entities so no need to call Update()
                _dbContext.SaveChanges();

                LoadItems();

                MessageBox.Show("Klient został pomyślnie zmodyfikowany.");
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Delete()
        {
            var msgboxResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczonego klienta?", "Usuwanie klienta", MessageBoxButton.YesNo);
            if (msgboxResult == MessageBoxResult.No) { return; }

            var orders = _dbContext.Orders.Where(o => o.ClientID == SelectedClient.ID);
            if (orders.Count() > 0)
            {
                msgboxResult = MessageBox.Show("Aby usunąć tego klienta najpierw program musi usunąć zlecenia do niego przypisane. Czy chcesz kontynuować?", "Usuwanie klienta", MessageBoxButton.YesNo);
                if (msgboxResult == MessageBoxResult.No) { return; }

                foreach (var order in orders)
                {
                    _dbContext.Orders.Remove(order);
                }
                _dbContext.SaveChanges();
            }

            _dbContext.Clients.Remove(SelectedClient);
            _dbContext.SaveChanges();

            Clients.Remove(SelectedClient);
            SelectedClient = null;

            MessageBox.Show("Adres został pomyślnie usunięty.");
        }

        [RelayCommand]
        private void AddNew()
        {
            var addNewWindow = new AddClientWindow();
            addNewWindow.ShowDialog();

            var result = addNewWindow.Result;

            if (result is not null)
            {
                _dbContext.Clients.Add(result);
                _dbContext.SaveChanges();

                LoadItems();

                MessageBox.Show("Klient został pomyślnie dodany.");
            }
        }
    }
}
