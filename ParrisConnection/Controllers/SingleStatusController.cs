using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private readonly IStatusService _service;

        public SingleStatusController(IStatusService service)
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
            status.UserId = User.Identity.GetUserId();
           _service.SaveStatus(status);

            return RedirectToAction("Index", "Wall");
        }
    }
}