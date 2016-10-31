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
        public ActionResult AddEmployment(ProfileViewModel profile)
        {
            _context.Employers.Add(profile.NewEmployment);

            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddEducation(ProfileViewModel profile)
        {
            _context.Educations.Add(profile.NewEducation);

            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddQuote(ProfileViewModel profile)
        {
            _context.Quotes.Add(profile.NewQuote);

            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult AddPhoneNumber(ProfileViewModel profile)
        {
            var phoneType = _context.PhoneTypes.ToList().Single(t => t.Id == profile.SelectedPhone);
            var phone = profile.NewPhone;
            phone.PhoneType = phoneType.Type;
             _context.Phones.Add(phone);

            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }
    }
}