﻿using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Education.Queries;
using ParrisConnection.ServiceLayer.Services.Education.Save;
using ParrisConnection.ServiceLayer.Services.Email.Queries;
using ParrisConnection.ServiceLayer.Services.Email.Save;
using ParrisConnection.ServiceLayer.Services.Employer.Queries;
using ParrisConnection.ServiceLayer.Services.Employer.Save;
using ParrisConnection.ServiceLayer.Services.Phone.Queries;
using ParrisConnection.ServiceLayer.Services.Phone.Save;
using ParrisConnection.ServiceLayer.Services.ProfilePhoto.Save;
using ParrisConnection.ServiceLayer.Services.Quote.Queries;
using ParrisConnection.ServiceLayer.Services.Quote.Save;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ParrisConnection.ServiceLayer.ViewModelServices.ProfileView;

namespace ParrisConnection.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileViewService _profileViewService;
        private readonly IEducationSaveService _educationSaveService;
        private readonly IEducationQueryService _educationQueryService;
        private readonly IEmailQueryService _emailQueryService;
        private readonly IEmailSaveService _emailSaveService;
        private readonly IEmployerSaveService _employerSaveService;
        private readonly IEmployerQueryService _employerQueryService;
        private readonly IPhoneQueryService _phoneQueryService;
        private readonly IPhoneSaveService _phoneSaveService;
        private readonly IProfilePhotoSaveService _profilePhotoSaveService;
        private readonly IQuoteQueryService _quoteQueryService;
        private readonly IQuoteSaveService _quoteSaveService;

        public ProfileController(  
            IProfileViewService profileViewService, IEducationSaveService educationSaveService, IEducationQueryService educationQueryService, IEmailQueryService emailQueryService, IEmailSaveService emailSaveService, IEmployerSaveService employerSaveService, IEmployerQueryService employerQueryService, IPhoneQueryService phoneQueryService, IPhoneSaveService phoneSaveService, IProfilePhotoSaveService profilePhotoSaveService, IQuoteQueryService quoteQueryService, IQuoteSaveService quoteSaveService)
        {
            _profileViewService = profileViewService;
            _educationSaveService = educationSaveService;
            _educationQueryService = educationQueryService;
            _emailQueryService = emailQueryService;
            _emailSaveService = emailSaveService;
            _employerSaveService = employerSaveService;
            _employerQueryService = employerQueryService;
            _phoneQueryService = phoneQueryService;
            _phoneSaveService = phoneSaveService;
            _profilePhotoSaveService = profilePhotoSaveService;
            _quoteQueryService = quoteQueryService;
            _quoteSaveService = quoteSaveService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            return User != null ? View(_profileViewService.GetViewModel(User.Identity.GetUserId())) : View();
        }

        [HttpPost]
        public ActionResult EditProfilePicture(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return RedirectToAction("Index", "Profile");

            try
            {
                _profilePhotoSaveService.UpdateProfilePhoto(file, Path.Combine(Server.MapPath("~/ProfilePhotos"), Path.GetFileName(file.FileName)), User.Identity.GetUserId());

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
             employment.UserId = User != null ? User.Identity.GetUserId() : "";

            _employerSaveService.SaveEmployer(employment);

            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("AddEmployment", _employerQueryService.GetEmployers());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEducation(EducationData education)
        {
            education.UserId = User != null ? User.Identity.GetUserId() : ""; 
            _educationSaveService.SaveEducation(education);
            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("AddEducation", _educationQueryService.GetAllEducation());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddQuote(QuoteData quote)
        {
            quote.UserId = User != null ? User.Identity.GetUserId() : "";
            _quoteSaveService.SaveQuote(quote);

            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("AddQuote", _quoteQueryService.GetQuotes());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddPhoneNumber(PhoneData phoneNumber)
        {
            phoneNumber.UserId = User != null ? User.Identity.GetUserId() : "";
            _phoneSaveService.SavePhone(phoneNumber);

            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("AddPhoneNumber", _phoneQueryService.GetPhones());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmail(EmailData email)
        {
            email.UserId = User != null ? User.Identity.GetUserId() : "";
            _emailSaveService.SaveEmail(email);

            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("AddEmail", _emailQueryService.GetEmails());
            }

            return RedirectToAction("Index", "Profile");
        }
    }
}