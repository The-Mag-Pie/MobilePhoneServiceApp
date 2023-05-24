using MobilePhoneServiceApp.ViewModels;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = ServiceHelper.GetService<MainWindowViewModel>();
        }
    }
}
