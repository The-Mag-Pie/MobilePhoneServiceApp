using MobilePhoneServiceApp.Database.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace MobilePhoneServiceApp.Windows
{
    public partial class AddModifyPhoneWindowBase : Window
    {
        public Phone? Result { get; private set; } = null;

        private readonly Phone _phone;

        public AddModifyPhoneWindowBase(Phone phone)
        {
            InitializeComponent();
            _phone = phone;
            DataContext = _phone;
        }

        private bool ValidateData()
        {
            var brand = _phone.Brand;
            var model = _phone.Model;
            var imei = _phone.IMEI;
            var photosURL = _phone.PhotosURL;

            var messageText = string.Empty;

            if (brand is null || brand == string.Empty)
            {
                messageText += "Marka nie może być pusta!\n";
            }

            if (model is null || model == string.Empty)
            {
                messageText += "Model nie może być pusty!\n";
            }

            if (imei is null || imei == string.Empty)
            {
                messageText += "IMEI nie może być pusty!\n";
            }

            if (photosURL is not null && photosURL != string.Empty)
            {
                try
                {
                    new Uri(photosURL);
                }
                catch
                {
                    messageText += "Niepoprawny URL do zdjęć telefonu!";
                }
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
                Result = _phone;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
