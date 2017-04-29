using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using System;

namespace ParrisConnection.ServiceLayer.Services.Email.Save
{
    public class EmailSaveService : IEmailSaveService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IMapper _emailMapper;

        public EmailSaveService(IDataAccess dataAccess, IEmailQueryService emailQueryService)
        {
            _dataAccess = dataAccess;
            _emailQueryService = emailQueryService;

            var emailConfig = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Email, EmailData>().ReverseMap());

            _emailMapper = new Mapper(emailConfig);
        }

        public void SaveEmail(EmailData email)
        {
            email.Type = _emailQueryService.GetEmailTypeById(Convert.ToInt32(email.Type)).Type;
            _dataAccess.Emails.Insert(_emailMapper.Map<DataLayer.Entities.Profile.Email>(email));
        }
    }
}
