using MobilePhoneServiceApp.ViewModels;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class DeliveryAddressesWindow : Window
    {
        public DeliveryAddressesWindow()
        {
            InitializeComponent();

            DataContext = ServiceHelper.GetService<DeliveryAddressesViewModel>();
        }
    }
}
