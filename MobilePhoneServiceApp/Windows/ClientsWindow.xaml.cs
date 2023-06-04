using MobilePhoneServiceApp.ViewModels;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();

            DataContext = ServiceHelper.GetService<ClientsViewModel>();
        }
    }
}
