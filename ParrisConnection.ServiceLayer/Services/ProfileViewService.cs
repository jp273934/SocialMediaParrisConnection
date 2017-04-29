using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Linq;
using ParrisConnection.ServiceLayer.Services.Education.Queries;

namespace ParrisConnection.ServiceLayer.Services
{
    public class ProfileViewService : IProfileViewService
    {
        private readonly IProfilePhotosService _profilePhotosService;
        private readonly IEmployerService _employerService;
        private readonly IQuoteService _quoteService;
        private readonly IPhoneService _phoneService;
        private readonly IEmailService _emailService;
        private readonly IDataAccess _dataAccess;
        private readonly IEducationQueryService _educationQueryService;

        public ProfileViewService(IProfilePhotosService profilePhotosService, IEmployerService employerService, IQuoteService quoteService, IPhoneService phoneService, IEmailService emailService, IDataAccess dataAccess, IEducationQueryService educationQueryService)
        {
            _profilePhotosService = profilePhotosService;
            _employerService = employerService;
            _quoteService = quoteService;
            _phoneService = phoneService;
            _emailService = emailService;
            _dataAccess = dataAccess;
            _educationQueryService = educationQueryService;
        }

        public ProfileViewModel GetViewModel(string userId)
        {
            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = _profilePhotosService.GetProfilePhoto(userId),
                Employers = _employerService.GetEmployers().Where(e => e.UserId == userId),
                Quotes = _quoteService.GetQuotes().Where(q => q.UserId == userId),
                Phones = _phoneService.GetPhones().Where(p => p.UserId == userId),
                Emails = _emailService.GetEmails().Where(e => e.UserId == userId),
                PhoneTypes = _phoneService.GetPhoneTypes(),
                EmailTypes = _dataAccess.EmailTypes.GetAll().ToList(),
                Educations = _educationQueryService.GetAllEducation().Where(e => e.UserId == userId)
            };

            return viewModel;
        }
    }
}
