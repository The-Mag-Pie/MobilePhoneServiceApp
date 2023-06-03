using MobilePhoneServiceApp.Database.Models;
using System.Text.RegularExpressions;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class AddModifyAddressWindowBase : Window
    {
        public DeliveryAddress? Result { get; private set; } = null;

        private readonly DeliveryAddress _address;

        public AddModifyAddressWindowBase(DeliveryAddress address)
        {
            InitializeComponent();
            _address = address;
            DataContext = _address;
        }

        private bool ValidateData()
        {
            var country = _address.Country;
            var city = _address.City;
            var postCode = _address.PostCode;
            var street = _address.Street;
            var houseNumber = _address.HouseNumber;

            var messageText = string.Empty;

            if (country is null || country == string.Empty)
            {
                messageText += "Kraj nie może być pusty!\n";
            }

            if (city is null || city == string.Empty)
            {
                messageText += "Miasto nie może być puste!\n";
            }

            if (postCode is null || postCode == string.Empty)
            {
                messageText += "Kod pocztowy nie może być pusty!\n";
            }
            //else if (IsPostCodeValid())
            //{
            //    messageText += "Kod pocztowy jest niepoprawny!\n";
            //}

            if (street is null || street == string.Empty)
            {
                messageText += "Ulica nie może być pusta!\n";
            }

            if (houseNumber is null || houseNumber == string.Empty)
            {
                messageText += "Numer domu nie może być pusty!\n";
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

        //private bool IsPostCodeValid()
        //{
        //    return new Regex("[0-9]{2}[-]([0-9]){3}").IsMatch(_address.PostCode);
        //}

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData() == true)
            {
                Result = _address;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
