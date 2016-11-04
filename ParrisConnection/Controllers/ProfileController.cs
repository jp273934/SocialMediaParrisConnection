using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParrisConnection.Models;
using ParrisConnection.Models.Profile;
using ParrisConnection.ViewModels;

namespace ParrisConnection.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Profile
        public ActionResult Index()
        {
            var profilePhotos = _context.ProfilePhotos.ToList();

            var viewModel = new ProfileViewModel
            {
                ProfilePhoto = profilePhotos.Count > 0 ? profilePhotos[0] : new ProfilePhoto(),
                Employers = _context.Employers.ToList(),
                Educations = _context.Educations.ToList(),
                Quotes = _context.Quotes.ToList(),
                Phones = _context.Phones.ToList(),
                Emails = _context.Emails.ToList(),
                PhoneTypes = _context.PhoneTypes.ToList(),
                EmailTypes = _context.EmailTypes.ToList()
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

                    _context.ProfilePhotos.ToList().Clear();

                    var photo = new ProfilePhoto
                    {
                        FilePath = file.FileName
                    };

                    _context.ProfilePhotos.Add(photo);
                    _context.SaveChanges();

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
            _context.Employers.Add(employment);

            _context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmployment", _context.Employers);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            _context.Educations.Add(education);

            _context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEducation", _context.Educations);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddQuote(Quote quote)
        {
            _context.Quotes.Add(quote);

            _context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddQuote", _context.Quotes);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddPhoneNumber(Phone phoneNumber)
        {
            var phoneTypes = _context.PhoneTypes.ToList();

            phoneNumber.PhoneType = phoneTypes.Single(p => p.Id == Convert.ToInt32(phoneNumber.PhoneType)).Type;

             _context.Phones.Add(phoneNumber);

            _context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddPhoneNumber", _context.Phones);
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEmail(Email email)
        {
            var emailTypes = _context.EmailTypes.ToList();
            email.EmailType = emailTypes.Single(e => e.Id == Convert.ToInt32(email.EmailType)).Type;
            
            _context.Emails.Add(email);

            _context.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AddEmail", _context.Emails);
            }

            return RedirectToAction("Index", "Profile");
        }
    }
}