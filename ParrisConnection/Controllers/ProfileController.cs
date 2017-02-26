﻿using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using ParrisConnection.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IDataAccess _context;
        private readonly IProfilePhotosService _profilePhotosService;
        private readonly IEmployerService _employerService;
        private readonly IEducationService _educationService;

        public ProfileController(IDataAccess context, IProfilePhotosService profilePhotosService, IEmployerService employerService, IEducationService educationService)
        {
            _context = context;
            _profilePhotosService = profilePhotosService;
            _employerService = employerService;
            _educationService = educationService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var profilePhotos = _context.ProfilePhotoes.GetAll().ToList();

            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = _profilePhotosService.GetProfilePhoto(),
                Employers = _employerService.GetEmployers(),
                Educations = _educationService.GetAllEducation(),
                Quotes = _context.Quotes.GetAll().ToList(),
                Phones = _context.Phones.GetAll().ToList(),
                Emails = _context.Emails.GetAll().ToList(),
                PhoneTypes = _context.PhoneTypes.GetAll().ToList(),
                EmailTypes = _context.EmailTypes.GetAll().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditProfilePicture(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0)
                return RedirectToAction("Index", "Profile");

            try
            {
                _profilePhotosService.UpdateProfilePhoto(file, Path.Combine(Server.MapPath("~/ProfilePhotos"), Path.GetFileName(file.FileName)));

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
            _educationService.SaveEducation(education);
            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEducation", _educationService.GetAllEducation());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddQuote(Quote quote)
        {
            _context.Quotes.Insert(quote);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddQuote", _context.Quotes.GetAll());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddPhoneNumber(Phone phoneNumber)
        {
            var phoneTypes = _context.PhoneTypes;

            //phoneNumber.PhoneType = phoneTypes.Single(p => p.Id == Convert.ToInt32(phoneNumber.PhoneType)).Type;

            // _context.Phones.Add(phoneNumber);

            //_context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddPhoneNumber", _context.Phones.GetAll());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmail(Email email)
        {
            var emailTypes = _context.EmailTypes.GetAll();
            //email.EmailType = emailTypes.Single(e => e.Id == Convert.ToInt32(email.EmailType)).Type;
            
            //_context.Emails.Add(email);

            //_context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmail", _context.Emails.GetAll());
            }

            return RedirectToAction("Index", "Profile");
        }
    }
}