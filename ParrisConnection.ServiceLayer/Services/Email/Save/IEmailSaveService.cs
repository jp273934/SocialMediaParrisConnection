using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Email.Save
{
    public interface IEmailSaveService
    {
        void SaveEmail(EmailData email);
    }
}