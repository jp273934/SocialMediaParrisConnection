using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services.Email.Queries
{
    public interface IEmailQueryService
    {
        IEnumerable<EmailTypeData> GetEmailTypes();
        EmailTypeData GetEmailTypeById(int id);
        IEnumerable<EmailData> GetEmails();
        IEnumerable<EmailData> GetEmailsByUserId(string userId);
        EmailData GetEmailById(int id);
    }
}