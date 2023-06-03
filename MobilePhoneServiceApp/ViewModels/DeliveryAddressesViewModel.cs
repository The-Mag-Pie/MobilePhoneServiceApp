using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using MobilePhoneServiceApp.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MobilePhoneServiceApp.ViewModels
{
    public partial class DeliveryAddressesViewModel : ObservableObject
    {
        public ObservableCollection<DeliveryAddress> Addresses { get; set; } = new();

        public bool CanBeExecuted => SelectedAddress is not null;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
        [NotifyCanExecuteChangedFor(nameof(ModifyCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private DeliveryAddress _selectedAddress;

        private readonly AppDbContext _dbContext;

        public DeliveryAddressesViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoadItems();
        }

        private void LoadItems()
        {
            Addresses.Clear();
            foreach (var item in _dbContext.DeliveryAddresses.OrderBy(d => d.ID))
            {
                Addresses.Add(item);
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void ShowDetails()
        {
            var text = $"ID: {SelectedAddress.ID}";
            text += $"\nKraj: {SelectedAddress.Country}";
            text += $"\nMiasto: {SelectedAddress.City}";
            text += $"\nKod pocztowy: {SelectedAddress.PostCode}";
            text += $"\nUlica: {SelectedAddress.Street}";
            text += $"\nNumer domu: {SelectedAddress.HouseNumber}";
            text += $"\nNr mieszkania: {SelectedAddress.ApartmentNumber}";

            MessageBox.Show(text, "Szczegóły adresu");
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Modify()
        {
            var modifyWindow = new ModifyAddressWindow(SelectedAddress);
            modifyWindow.ShowDialog();

            var result = modifyWindow.Result;

            if (result is not null)
            {
                SelectedAddress.Country = result.Country;
                SelectedAddress.City = result.City;
                SelectedAddress.PostCode = result.PostCode;
                SelectedAddress.Street = result.Street;
                SelectedAddress.HouseNumber = result.HouseNumber;
                SelectedAddress.ApartmentNumber = result.ApartmentNumber;

                // SelectedAddress is one of tracked entities so no need to call Update()
                _dbContext.SaveChanges();

                LoadItems();

                MessageBox.Show("Adres został pomyślnie zmodyfikowany.");
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Delete()
        {
            var msgboxResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony adres?", "Usuwanie adresu", MessageBoxButton.YesNo);
            if (msgboxResult == MessageBoxResult.No) { return; }

            var orders = _dbContext.Orders.Where(o => o.ShippingAddressID == SelectedAddress.ID);
            foreach (var order in orders)
            {
                order.ShippingAddressID = null;
            }
            _dbContext.SaveChanges();

            _dbContext.DeliveryAddresses.Remove(SelectedAddress);
            _dbContext.SaveChanges();

            Addresses.Remove(SelectedAddress);
            SelectedAddress = null;

            MessageBox.Show("Adres został pomyślnie usunięty.");
        }

        [RelayCommand]
        private void AddNew()
        {
            var addNewWindow = new AddAddressWindow();
            addNewWindow.ShowDialog();

            var result = addNewWindow.Result;

            if (result is not null)
            {
                _dbContext.DeliveryAddresses.Add(result);
                _dbContext.SaveChanges();

                LoadItems();

                MessageBox.Show("Adres został pomyślnie dodany.");
            }
        }
    }
}
