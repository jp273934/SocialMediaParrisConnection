﻿using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities.Profile;
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
        private IDataAccess _context;

        public ProfileController(IDataAccess context)
        {
            _context = context;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var profilePhotos = _context.ProfilePhotoes.GetAll().ToList();

            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = profilePhotos.Count > 0 ? profilePhotos[0] : new DataLayer.Entities.Profile.ProfilePhoto(),
                Employers = _context.Employers.GetAll().ToList(),
                Educations = _context.Educations.GetAll().ToList(),
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
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/ProfilePhotos"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    _context.ProfilePhotoes.GetAll().ToList().Clear();

                    var photo = new ProfilePhoto
                    {
                        FilePath = file.FileName
                    };

                    _context.ProfilePhotoes.Insert(photo);

                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error : " + e.Message;
                }
            }
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmployment(Employer employment)
        {
            _context.Employers.Insert(employment);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmployment", _context.Employers.GetAll());
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            _context.Educations.Insert(education);

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEducation", _context.Educations.GetAll());
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