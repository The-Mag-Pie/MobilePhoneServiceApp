using MobilePhoneServiceApp.Database.Models;

namespace MobilePhoneServiceApp.Windows
{
    public class ModifyPhoneWindow : AddModifyPhoneWindowBase
    {
        public ModifyPhoneWindow(Phone phone) : base(new()
        {
            ID = phone.ID,
            Brand = phone.Brand,
            Model = phone.Model,
            IMEI = phone.IMEI,
            PhotosURL = phone.PhotosURL
        })
        {
            Title = "Modyfikacja telefonu";
        }
    }
}
