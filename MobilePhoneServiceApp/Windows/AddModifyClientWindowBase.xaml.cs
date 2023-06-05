using MobilePhoneServiceApp.Database.Models;
using System.Text.RegularExpressions;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class AddModifyClientWindowBase : Window
    {
        private static bool IsEmailValid(string email)
        {
            return new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").IsMatch(email);
        }

        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            return new Regex("^\\+?[1-9][0-9]{7,14}$").IsMatch(phoneNumber);
        }

        public Client? Result { get; private set; } = null;

        private readonly Client _client;

        public AddModifyClientWindowBase(Client client)
        {
            InitializeComponent();
            _client = client;
            DataContext = _client;
        }

        private bool ValidateData()
        {
            var firstName = _client.FirstName;
            var lastName = _client.LastName;
            var country = _client.Country;
            var city = _client.City;
            var street = _client.Street;
            var houseNumber = _client.HouseNumber;
            var email = _client.Email;
            var phoneNumber = _client.PhoneNumber;

            var messageText = string.Empty;

            if (firstName is null || firstName == string.Empty)
            {
                messageText += "Imię nie może być puste!\n";
            }

            if (lastName is null || lastName == string.Empty)
            {
                messageText += "Nazwisko nie może być puste!\n";
            }

            if (country is null || country == string.Empty)
            {
                messageText += "Kraj nie może być pusty!\n";
            }

            if (city is null || city == string.Empty)
            {
                messageText += "Miasto nie może być puste!\n";
            }

            if (street is null || street == string.Empty)
            {
                messageText += "Ulica nie może być pusta!\n";
            }

            if (houseNumber is null || houseNumber == string.Empty)
            {
                messageText += "Numer domu nie może być pusty!\n";
            }

            if (email is not null && IsEmailValid(email) == false)
            {
                messageText += "Niepoprawny email!\n";
            }

            if (phoneNumber is null || phoneNumber == string.Empty)
            {
                messageText += "Numer telefonu nie może być pusty!\n";
            }
            else if (IsPhoneNumberValid(phoneNumber) == false)
            {
                messageText += "Numer telefonu jest niepoprawny!\n";
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

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData() == true)
            {
                Result = _client;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
