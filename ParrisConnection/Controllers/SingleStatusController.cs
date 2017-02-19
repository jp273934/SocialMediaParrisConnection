using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities;
using System.Web.Mvc;
using Status = ParrisConnection.DataLayer.Entities.Wall.Status;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private DataAccess _context;

        public SingleStatusController()
        {
            _context = new DataAccess(new ParrisDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStatus(Status status)
        {
            _context.Statuses.Insert(status);

            return RedirectToAction("Index", "Wall");
        }
    }
}