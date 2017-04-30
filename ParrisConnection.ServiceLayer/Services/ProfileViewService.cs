using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries;
using System.Linq;

namespace ParrisConnection.ServiceLayer.Services
{
    public class ProfileViewService : IProfileViewService
    {
        private readonly IQuoteService _quoteService;
        private readonly IDataAccess _dataAccess;
        private readonly IEducationQueryService _educationQueryService;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IEmployerQueryService _employerQueryService;
        private readonly IPhoneQueryService _phoneQueryService;
        private readonly IProfilePhotoQueryService _profilePhotoQueryService;

        public ProfileViewService(IQuoteService quoteService, IDataAccess dataAccess, IEducationQueryService educationQueryService, IEmailQueryService emailQueryService, IEmployerQueryService employerQueryService, IPhoneQueryService phoneQueryService, IProfilePhotoQueryService profilePhotoQueryService)
        {
            _quoteService = quoteService;
            _dataAccess = dataAccess;
            _educationQueryService = educationQueryService;
            _emailQueryService = emailQueryService;
            _employerQueryService = employerQueryService;
            _phoneQueryService = phoneQueryService;
            _profilePhotoQueryService = profilePhotoQueryService;
        }

        public ProfileViewModel GetViewModel(string userId)
        {
            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = _profilePhotoQueryService.GetProfilePhoto(userId),
                Employers = _employerQueryService.GetEmployers().Where(e => e.UserId == userId),
                Quotes = _quoteService.GetQuotes().Where(q => q.UserId == userId),
                Phones = _phoneQueryService.GetPhones().Where(p => p.UserId == userId),
                Emails = _emailQueryService.GetEmails().Where(e => e.UserId == userId),
                PhoneTypes = _phoneQueryService.GetPhoneTypes(),
                EmailTypes = _dataAccess.EmailTypes.GetAll().ToList(),
                Educations = _educationQueryService.GetAllEducation().Where(e => e.UserId == userId)
            };

            return viewModel;
        }
    }
}
