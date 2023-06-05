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
    public partial class OrdersViewModel : ObservableObject
    {
        public ObservableCollection<Order> Orders { get; set; } = new();

        public bool CanBeExecuted => SelectedOrder is not null;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
        [NotifyCanExecuteChangedFor(nameof(ModifyCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Order _selectedOrder;

        private readonly AppDbContext _dbContext;

        public OrdersViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoadItems();
        }

        private void LoadItems()
        {
            Orders.Clear();
            foreach (var item in _dbContext.Orders.OrderBy(p => p.ID))
            {
                Orders.Add(item);
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void ShowDetails()
        {
            var text = $"ID: {SelectedOrder.ID}";
            text += $"\nOpis szkody: {SelectedOrder.DamageDescription}";

            var orderStatus = _dbContext.OrderStatuses.Where(s => s.ID == SelectedOrder.OrderStatusID).Single();
            text += $"\nStatus zlecenia: {orderStatus.StatusName}";

            if (SelectedOrder.ShippingAddressID is not null)
            {
                var deliveryAddress = _dbContext.DeliveryAddresses.Where(d => d.ID == SelectedOrder.ShippingAddressID).Single();
                text += $"\nAdres do przesyłki: {deliveryAddress.City}, ul. {deliveryAddress.Street} {deliveryAddress.HouseNumber} {deliveryAddress.ApartmentNumber ?? null}, {deliveryAddress.Country.ToUpper()}";
            }
            else
            {
                text += "\nAdres do przesyłki: brak";
            }

            var client = _dbContext.Clients.Where(c => c.ID == SelectedOrder.ClientID).Single();
            text += $"\nImię i nazwisko klienta: {client.FirstName} {client.LastName}";

            var phone = _dbContext.Phones.Where(p => p.ID == SelectedOrder.PhoneID).Single();
            text += $"\nMarka i model telefonu: {phone.Brand} {phone.Model}";

            if (SelectedOrder.RepairEmployeeID is not null)
            {
                var repairEmployee = _dbContext.Employees.Where(e => e.ID == SelectedOrder.RepairEmployeeID).Single();
                text += $"\nImię i nazwisko serwisanta: {repairEmployee.FirstName} {repairEmployee.LastName}";
            }
            else
            {
                text += "\nImię i nazwisko serwisanta: nie przypisano";
            }

            if (SelectedOrder.CustomerServiceEmployeeID is not null)
            {
                var customerServiceEmployee = _dbContext.Employees.Where(e => e.ID == SelectedOrder.CustomerServiceEmployeeID).Single();
                text += $"\nImię i nazwisko pracownika obsługi klienta: {customerServiceEmployee.FirstName} {customerServiceEmployee.LastName}";
            }
            else
            {
                text += "\nImię i nazwisko pracownika obsługi klienta: nie przypisano";
            }

            MessageBox.Show(text, "Szczegóły zlecenia");
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Modify()
        {
            var modifyWindow = new ModifyOrderWindow(SelectedOrder);
            modifyWindow.ShowDialog();

            //var result = modifyWindow.Result;

            //if (result is not null)
            //{
            //    SelectedPhone.Brand = result.Brand;
            //    SelectedPhone.Model = result.Model;
            //    SelectedPhone.IMEI = result.IMEI;
            //    SelectedPhone.PhotosURL = result.PhotosURL;

            //    // SelectedPhone is one of tracked entities so no need to call Update()
            //    _dbContext.SaveChanges();

            //    LoadItems();

            //    MessageBox.Show("Telefon został pomyślnie zmodyfikowany.");
            //}
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Delete()
        {
            var msgboxResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone zlecenie?", "Usuwanie zlecenia", MessageBoxButton.YesNo);
            if (msgboxResult == MessageBoxResult.No) { return; }

            _dbContext.Orders.Remove(SelectedOrder);
            _dbContext.SaveChanges();

            Orders.Remove(SelectedOrder);
            SelectedOrder = null;

            MessageBox.Show("Zlecenie zostało pomyślnie usunięte.");
        }

        [RelayCommand]
        private void AddNew()
        {
            var addNewWindow = new AddOrderWindow();
            addNewWindow.ShowDialog();

            //var result = addNewWindow.Result;

            //if (result is not null)
            //{
            //    _dbContext.Orders.Add(result);
            //    _dbContext.SaveChanges();

            //    LoadItems();

            //    MessageBox.Show("Telefon został pomyślnie dodany.");
            //}
        }
    }
}
