using System.Collections.Generic;
using ParrisConnection.ServiceLayer.Data;

namespace ParrisConnection.ServiceLayer.Services.Email.Queries
{
    public interface IEmailQueryService
    {
        IEnumerable<EmailTypeData> GetEmailTypes();
        EmailTypeData GetEmailTypeById(int id);
        IEnumerable<EmailData> GetEmails();
        EmailData GetEmailById(int id);
    }
}