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
                ProfilePhoto = profilePhotos.Count > 0 ? profilePhotos[0] : new ProfilePhoto()
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

                    var profilePhotos = _context.ProfilePhotos.ToList();

                    profilePhotos.Clear();

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
    }
}