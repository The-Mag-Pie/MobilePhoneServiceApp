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
    public partial class PhonesViewModel : ObservableObject
    {
        public ObservableCollection<Phone> Phones { get; set; } = new();

        public bool CanBeExecuted => SelectedPhone is not null;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
        [NotifyCanExecuteChangedFor(nameof(ModifyCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Phone _selectedPhone;

        private readonly AppDbContext _dbContext;

        public PhonesViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoadItems();
        }

        private void LoadItems()
        {
            Phones.Clear();
            foreach (var item in _dbContext.Phones.OrderBy(p => p.ID))
            {
                Phones.Add(item);
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void ShowDetails()
        {
            var text = $"ID: {SelectedPhone.ID}";
            text += $"\nMarka: {SelectedPhone.Brand}";
            text += $"\nModel: {SelectedPhone.Model}";
            text += $"\nIMEI: {SelectedPhone.IMEI}";
            text += $"\nZdjęcia URL: {SelectedPhone.PhotosURL}";

            MessageBox.Show(text, "Szczegóły telefonu");
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Modify()
        {
            var modifyWindow = new ModifyPhoneWindow(SelectedPhone);
            modifyWindow.ShowDialog();

            var result = modifyWindow.Result;

            if (result is not null)
            {
                SelectedPhone.Brand = result.Brand;
                SelectedPhone.Model = result.Model;
                SelectedPhone.IMEI = result.IMEI;
                SelectedPhone.PhotosURL = result.PhotosURL;

                // SelectedPhone is one of tracked entities so no need to call Update()
                _dbContext.SaveChanges();

                LoadItems();

                MessageBox.Show("Telefon został pomyślnie zmodyfikowany.");
            }
        }

        [RelayCommand(CanExecute = nameof(CanBeExecuted))]
        private void Delete()
        {
            var msgboxResult = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony telefon?", "Usuwanie telefonu", MessageBoxButton.YesNo);
            if (msgboxResult == MessageBoxResult.No) { return; }

            var order = _dbContext.Orders.Where(o => o.PhoneID == SelectedPhone.ID).FirstOrDefault();
            if (order is not null)
            {
                msgboxResult = MessageBox.Show("Aby usunąć ten telefon najpierw program musi usunąć zlecenie. Czy chcesz kontynuować?", "Usuwanie telefonu", MessageBoxButton.YesNo);
                if (msgboxResult == MessageBoxResult.No) { return; }

                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }

            _dbContext.Phones.Remove(SelectedPhone);
            _dbContext.SaveChanges();

            Phones.Remove(SelectedPhone);
            SelectedPhone = null;

            MessageBox.Show("Telefon został pomyślnie usunięty.");
        }

        [RelayCommand]
        private void AddNew()
        {
            var addNewWindow = new AddPhoneWindow();
            addNewWindow.ShowDialog();

            var result = addNewWindow.Result;

            if (result is not null)
            {
                _dbContext.Phones.Add(result);
                _dbContext.SaveChanges();
                
                LoadItems();

                MessageBox.Show("Telefon został pomyślnie dodany.");
            }
        }
    }
}
