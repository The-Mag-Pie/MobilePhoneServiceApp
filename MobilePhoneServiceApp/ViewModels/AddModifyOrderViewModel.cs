using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MobilePhoneServiceApp.ViewModels
{
    public partial class AddModifyOrderViewModel : ObservableObject
    {
        private readonly Order _order;
        private readonly AppDbContext _dbContext;

        public Order Order => _order;

        public List<OrderStatus> OrderStatuses =>
            _dbContext.OrderStatuses.OrderBy(s => s.ID).ToList();

        public OrderStatus SelectedOrderStatus
        {
            get => OrderStatuses.Where(s => s.ID == Order.OrderStatusID).FirstOrDefault();
            set => _order.OrderStatusID = value.ID;
        }

        public List<DeliveryAddress> DeliveryAddresses =>
            _dbContext.DeliveryAddresses.OrderByDescending(s => s.ID).ToList();

        public DeliveryAddress? SelectedDeliveryAddress
        {
            get => DeliveryAddresses.Where(d => d.ID == Order.ShippingAddressID).FirstOrDefault();
            set => _order.ShippingAddressID = value?.ID;
        }

        public List<Client> Clients =>
            _dbContext.Clients.OrderByDescending(s => s.ID).ToList();

        public Client SelectedClient
        {
            get => Clients.Where(d => d.ID == Order.ClientID).FirstOrDefault();
            set => _order.ClientID = value.ID;
        }

        public List<Employee> RepairEmployees =>
            _dbContext.Employees
            .Where(e => _dbContext.Departments
                .Where(d => d.DepartmentName == "Serwis").Single().ID == e.DepartmentID)
            .OrderBy(e => e.LastName)
            .ToList();

        public Employee? SelectedRepairEmployee
        {
            get => RepairEmployees.Where(e => e.ID == Order.RepairEmployeeID).FirstOrDefault();
            set => _order.RepairEmployeeID = value?.ID;
        }

        public List<Employee> CustomerServiceEmployees =>
            _dbContext.Employees
            .Where(e => _dbContext.Departments
                .Where(d => d.DepartmentName == "Obsługa klienta").Single().ID == e.DepartmentID)
            .OrderBy(e => e.LastName)
            .ToList();

        public Employee? SelectedCustomerServiceEmployee
        {
            get => CustomerServiceEmployees.Where(e => e.ID == Order.CustomerServiceEmployeeID).FirstOrDefault();
            set => _order.CustomerServiceEmployeeID = value?.ID;
        }

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

        [RelayCommand]
        private void ClearDeliveryAddress()
        {
            SelectedDeliveryAddress = null;
            OnPropertyChanged(nameof(SelectedDeliveryAddress));
        }

        [RelayCommand]
        private void ClearRepairEmployee()
        {
            SelectedRepairEmployee = null;
            OnPropertyChanged(nameof(SelectedRepairEmployee));
        }

        [RelayCommand]
        private void ClearCustomerServiceEmployee()
        {
            SelectedCustomerServiceEmployee = null;
            OnPropertyChanged(nameof(SelectedCustomerServiceEmployee));
        }
    }
}
