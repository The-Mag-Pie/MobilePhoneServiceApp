using MobilePhoneServiceApp.ViewModels;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class PhonesWindow : Window
    {
        public PhonesWindow()
        {
            InitializeComponent();

            DataContext = ServiceHelper.GetService<PhonesViewModel>();
        }
    }
}
