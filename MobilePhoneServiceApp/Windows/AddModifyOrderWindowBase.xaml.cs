using MobilePhoneServiceApp.Database;
using MobilePhoneServiceApp.Database.Models;
using MobilePhoneServiceApp.ViewModels;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class AddModifyOrderWindowBase : Window
    {
        private readonly AddModifyOrderViewModel _viewModel;

        public Order? Result { get; private set; } = null;

        public AddModifyOrderWindowBase(Order order)
        {
            InitializeComponent();

            _viewModel = new(order);
            DataContext = _viewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateData() == true)
            {
                var dbContext = ServiceHelper.GetService<AppDbContext>();

                if (_viewModel.AssignedPhone.ID == null)
                {
                    dbContext.Phones.Add(_viewModel.AssignedPhone);
                }
                else
                {
                    dbContext.ChangeTracker.Clear();
                    dbContext.Phones.Update(_viewModel.AssignedPhone);
                }
                dbContext.SaveChanges();

                _viewModel.Order.PhoneID = _viewModel.AssignedPhone.ID;

                Result = _viewModel.Order;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
