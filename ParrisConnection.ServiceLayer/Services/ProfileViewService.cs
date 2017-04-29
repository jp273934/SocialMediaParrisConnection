using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Linq;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;

namespace ParrisConnection.ServiceLayer.Services
{
    public class ProfileViewService : IProfileViewService
    {
        private readonly IProfilePhotosService _profilePhotosService;
        private readonly IQuoteService _quoteService;
        private readonly IPhoneService _phoneService;
        private readonly IDataAccess _dataAccess;
        private readonly IEducationQueryService _educationQueryService;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IEmployerQueryService _employerQueryService;

        public ProfileViewService(IProfilePhotosService profilePhotosService, IQuoteService quoteService, IPhoneService phoneService, IDataAccess dataAccess, IEducationQueryService educationQueryService, IEmailQueryService emailQueryService, IEmployerQueryService employerQueryService)
        {
            _profilePhotosService = profilePhotosService;
            _quoteService = quoteService;
            _phoneService = phoneService;
            _dataAccess = dataAccess;
            _educationQueryService = educationQueryService;
            _emailQueryService = emailQueryService;
            _employerQueryService = employerQueryService;
        }

        public ProfileViewModel GetViewModel(string userId)
        {
            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = _profilePhotosService.GetProfilePhoto(userId),
                Employers = _employerQueryService.GetEmployers().Where(e => e.UserId == userId),
                Quotes = _quoteService.GetQuotes().Where(q => q.UserId == userId),
                Phones = _phoneService.GetPhones().Where(p => p.UserId == userId),
                Emails = _emailQueryService.GetEmails().Where(e => e.UserId == userId),
                PhoneTypes = _phoneService.GetPhoneTypes(),
                EmailTypes = _dataAccess.EmailTypes.GetAll().ToList(),
                Educations = _educationQueryService.GetAllEducation().Where(e => e.UserId == userId)
            };

            return viewModel;
        }
    }
}
