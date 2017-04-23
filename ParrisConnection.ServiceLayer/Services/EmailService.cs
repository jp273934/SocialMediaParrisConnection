using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ParrisConnection.ServiceLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _emailMapper;

        public EmailService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<EmailType, EmailTypeData>().ReverseMap());
            var emailConfig = new MapperConfiguration(m => m.CreateMap<Email, EmailData>().ReverseMap());

            _mapper = new Mapper(config);
            _emailMapper = new Mapper(emailConfig);
        }

        #region EmailTypes
        public IEnumerable<EmailTypeData> GetEmailTypes()
        {
            return _mapper.Map<IEnumerable<EmailTypeData>>(_dataAccess.EmailTypes.GetAll());
        }

        public EmailTypeData GetEmailTypeById(int id)
        {
            return _mapper.Map<EmailTypeData>(_dataAccess.EmailTypes.GetById(id));
        }
        #endregion

        #region Email
        public IEnumerable<EmailData> GetEmails()
        {
            return _emailMapper.Map<IEnumerable<EmailData>>(_dataAccess.Emails.GetAll());
        }

        public EmailData GetEmailById(int id)
        {
            return _emailMapper.Map<EmailData>(_dataAccess.Emails.GetById(id));
        }

        public void SaveEmail(EmailData email)
        {
            email.Type = GetEmailTypeById(Convert.ToInt32(email.Type)).Type;
            _dataAccess.Emails.Insert(_emailMapper.Map<Email>(email));
        }
        #endregion
    }
}
