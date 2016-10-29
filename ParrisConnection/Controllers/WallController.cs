using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParrisConnection.Models;
using ParrisConnection.Models.Wall;

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
    }
}