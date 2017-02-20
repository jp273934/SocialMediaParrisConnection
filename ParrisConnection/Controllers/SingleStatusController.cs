using ParrisConnection.DataLayer.DataAccess;
using System.Web.Mvc;
using Status = ParrisConnection.DataLayer.Entities.Wall.Status;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private readonly IDataAccess _context;

        public SingleStatusController(IDataAccess context)
        {
            _context = context;
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