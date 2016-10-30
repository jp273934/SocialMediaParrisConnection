using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParrisConnection.Models;
using ParrisConnection.Models.Wall;
using ParrisConnection.ViewModels;

namespace ParrisConnection.Controllers
{
    public class WallController : Controller
    {
        private ApplicationDbContext _context;

        public WallController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var wall = new WallViewModel
            {
                Statuses = _context.Statuses.ToList()
            };

            return View(wall);
        }

        [HttpPost]
        public ActionResult CreateComment(int statusId, string comment)
        {
            var post = new Comment
            {
                PostComment = comment
            };

            _context.Statuses.Single(s => s.Id == statusId).Comments.Add(post);

             _context.SaveChanges();
         

            
            return RedirectToAction("Index", "Wall");
        }
    }
}