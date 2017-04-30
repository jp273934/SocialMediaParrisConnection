using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.ServiceLayer.Models;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Queries;
using ParrisConnection.ServiceLayer.Services.Quote.Queries;
using System.Linq;

namespace ParrisConnection.ServiceLayer.ViewModelServices.ProfileView
{
    public class ProfileViewService : IProfileViewService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IEducationQueryService _educationQueryService;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IEmployerQueryService _employerQueryService;
        private readonly IPhoneQueryService _phoneQueryService;
        private readonly IProfilePhotoQueryService _profilePhotoQueryService;
        private readonly IQuoteQueryService _quoteQueryService;

        public ProfileViewService(IDataAccess dataAccess, IEducationQueryService educationQueryService, IEmailQueryService emailQueryService, IEmployerQueryService employerQueryService, IPhoneQueryService phoneQueryService, IProfilePhotoQueryService profilePhotoQueryService, IQuoteQueryService quoteQueryService)
        {
            _dataAccess = dataAccess;
            _educationQueryService = educationQueryService;
            _emailQueryService = emailQueryService;
            _employerQueryService = employerQueryService;
            _phoneQueryService = phoneQueryService;
            _profilePhotoQueryService = profilePhotoQueryService;
            _quoteQueryService = quoteQueryService;
        }

        public ProfileViewModel GetViewModel(string userId)
        {
            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = _profilePhotoQueryService.GetProfilePhoto(userId),
                Employers = _employerQueryService.GetEmployersByUserId(userId),
                Quotes = _quoteQueryService.GetQuotesByUserId(userId),
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
