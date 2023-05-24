using System.Windows;

namespace MobilePhoneServiceApp
{
    public partial class App : Application
    {
        public App()
        {
            ServiceHelper.CreateServiceProvider();
        }
    }
}
