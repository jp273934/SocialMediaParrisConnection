using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private readonly IWallService _service;

        public SingleStatusController(IWallService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStatus(StatusData status)
        {
            _service.SaveStatus(status);

            return RedirectToAction("Index", "Wall");
        }
    }
}