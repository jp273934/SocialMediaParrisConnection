using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Interfaces
{
    public interface IEmailService
    {
        IEnumerable<EmailTypeData> GetEmailTypes();
        EmailTypeData GetEmailTypeById(int id);
        IEnumerable<EmailData> GetEmails();
        EmailData GetEmailById(int id);
        void SaveEmail(EmailData email);
    }
}