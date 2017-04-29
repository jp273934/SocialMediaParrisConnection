using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Education.Save;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Save;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfilePhotosService _profilePhotosService;
        private readonly IEmployerService _employerService;
        private readonly IQuoteService _quoteService;
        private readonly IPhoneService _phoneService;
        private readonly IProfileViewService _profileViewService;
        private readonly IEducationSaveService _educationSaveService;
        private readonly IEducationQueryService _educationQueryService;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IEmailSaveService _emailSaveService;

        public ProfileController( IProfilePhotosService profilePhotosService, IEmployerService employerService, 
            IQuoteService quoteService, IPhoneService phoneService, IProfileViewService profileViewService, IEducationSaveService educationSaveService, IEducationQueryService educationQueryService, IEmailQueryService emailQueryService, IEmailSaveService emailSaveService)
        {
            _profilePhotosService = profilePhotosService;
            _employerService = employerService;
            _quoteService = quoteService;
            _phoneService = phoneService;
            _profileViewService = profileViewService;
            _educationSaveService = educationSaveService;
            _educationQueryService = educationQueryService;
            _emailQueryService = emailQueryService;
            _emailSaveService = emailSaveService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View(_profileViewService.GetViewModel(User.Identity.GetUserId()));
        }

        [HttpPost]
        public ActionResult EditProfilePicture(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return RedirectToAction("Index", "Profile");

            try
            {
                _profilePhotosService.UpdateProfilePhoto(file, Path.Combine(Server.MapPath("~/ProfilePhotos"), Path.GetFileName(file.FileName)), User.Identity.GetUserId());

            }
            catch (Exception e)
            {
                ViewBag.Message = "Error : " + e.Message;
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmployment(EmployerData employment)
        {
            employment.UserId = User.Identity.GetUserId();
            _employerService.SaveEmployer(employment);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmployment", _employerService.GetEmployers());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEducation(EducationData education)
        {
            education.UserId = User.Identity.GetUserId();
            _educationSaveService.SaveEducation(education);
            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEducation", _educationQueryService.GetAllEducation());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddQuote(QuoteData quote)
        {
            quote.UserId = User.Identity.GetUserId();
            _quoteService.SaveQuote(quote);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddQuote", _quoteService.GetQuotes());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddPhoneNumber(PhoneData phoneNumber)
        {
            phoneNumber.UserId = User.Identity.GetUserId();
            _phoneService.SavePhone(phoneNumber);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddPhoneNumber", _phoneService.GetPhones());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmail(EmailData email)
        {
            email.UserId = User.Identity.GetUserId();
            _emailSaveService.SaveEmail(email);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmail", _emailQueryService.GetEmails());
            }

            return RedirectToAction("Index", "Profile");
        }
    }
}