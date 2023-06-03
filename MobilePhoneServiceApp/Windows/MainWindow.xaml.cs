using System.Windows;
using System.Windows.Input;

namespace MobilePhoneServiceApp.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RepairOrders_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<OrdersWindow>();
        }

        private void Phones_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<PhonesWindow>();
        }

        private void DeliveryAddresses_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<DeliveryAddressesWindow>();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowWindow<T>() where T : Window, new()
        {
            Cursor = Cursors.Wait;

            var window = new T();

            // Hide current window, show selected window and wait for closing, show current window
            Hide();
            window.ShowDialog();
            Show();

            Cursor = null;
        }
    }
}
