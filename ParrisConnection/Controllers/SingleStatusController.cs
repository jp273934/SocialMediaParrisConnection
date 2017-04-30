using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Status.Save;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class SingleStatusController : Controller
    {
        private readonly IStatusSaveService _statusSaveService;

        public SingleStatusController(IStatusSaveService statusSaveService)
        {
            _statusSaveService = statusSaveService;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStatus(StatusData status)
        {
            status.UserId = User != null ? User.Identity.GetUserId() : "";
           _statusSaveService.SaveStatus(status);

            return RedirectToAction("Index", "Wall");
        }
    }
}