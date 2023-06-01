using System.Windows;

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
            ShowWindow(new OrdersWindow());
        }

        private void Phones_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new PhonesWindow());
        }

        private void DeliveryAddresses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowWindow(Window window)
        {
            // Hide current window, show selected window and wait for closing, show current window
            Hide();
            window.ShowDialog();
            Show();
        }
    }
}
