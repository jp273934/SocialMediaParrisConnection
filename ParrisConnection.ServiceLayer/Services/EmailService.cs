using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IDataAccess _dataAccess;

        public EmailService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #region EmailTypes
        public IEnumerable<EmailTypeData> GetEmailTypes()
        {
            return _dataAccess.EmailTypes.GetAll().Select(LoadEmailType);
        }

        public EmailTypeData GetEmailTypeById(int id)
        {
            return LoadEmailType(_dataAccess.EmailTypes.GetById(id));
        }

        private EmailTypeData LoadEmailType(EmailType type)
        {
            return new EmailTypeData
            {
                Id = type.Id,
                Type = type.Type
            };
        }

        private EmailType ConvertToEntityEmailType(EmailTypeData type)
        {
            return new EmailType
            {
                Id = type.Id,
                Type = type.Type
            };
        }
        #endregion

        #region Email
        public IEnumerable<EmailData> GetEmails()
        {
            return _dataAccess.Emails.GetAll().Select(LoadEmailData);
        }

        public EmailData GetEmailById(int id)
        {
            return LoadEmailData(_dataAccess.Emails.GetById(id));
        }

        public void SaveEmail(EmailData email)
        {
            email.Type = GetEmailTypeById(Convert.ToInt32(email.Type)).Type;
            _dataAccess.Emails.Insert(ConvertToEntityEmail(email));
        }

        private EmailData LoadEmailData(Email email)
        {
            return new EmailData
            {
                Id      = email.Id,
                UserId  = email.UserId,
                Address = email.Address,
                Type    = email.Type
            };
        }

        private Email ConvertToEntityEmail(EmailData email)
        {
            return new Email
            {
                Id      = email.Id,
                UserId  = email.UserId,
                Address = email.Address,
                Type    = email.Type
            };
        }
        #endregion
    }
}
