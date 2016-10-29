using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParrisConnection.Models;
using ParrisConnection.Models.Wall;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private ApplicationDbContext _context;

        public SingleStatusController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStatus(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();

            return RedirectToAction("Index", "Wall");
        }
    }
}