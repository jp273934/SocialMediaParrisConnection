using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Phone.Save
{
    public interface IPhoneSaveService
    {
        void SavePhone(PhoneData phone);
    }
}