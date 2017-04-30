using AutoMapper;
using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services.Email.Queries
{
    public class EmailQueryService : IEmailQueryService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly IMapper _emailMapper;

        public EmailQueryService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            var config = new MapperConfiguration(m => m.CreateMap<EmailType, EmailTypeData>().ReverseMap());
            var emailConfig = new MapperConfiguration(m => m.CreateMap<DataLayer.Entities.Profile.Email, EmailData>().ReverseMap());

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
#        endregion

        #region Email
        public IEnumerable<EmailData> GetEmails()
        {
            return _emailMapper.Map<IEnumerable<EmailData>>(_dataAccess.Emails.GetAll());
        }

        public IEnumerable<EmailData> GetEmailsByUserId(string userId)
        {
            return _emailMapper.Map<IEnumerable<EmailData>>(_dataAccess.Emails.GetAll().Where(e => e.UserId == userId));
        }

        public EmailData GetEmailById(int id)
        {
            return _emailMapper.Map<EmailData>(_dataAccess.Emails.GetById(id));
        }
        #endregion 
    }
}
