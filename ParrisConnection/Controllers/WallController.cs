using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using ParrisConnection.ViewModels;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class WallController : Controller
    {

        private readonly IWallService _service;

        public WallController(IWallService service)
        {
           _service  = service;
        }

        public ActionResult Index()
        {
            var wall = new WallViewModel
            {
                Statuses = _service.GetStatuses()
            };

            return View(wall);
        }

        [HttpPost]
        public ActionResult CreateComment(int statusId, string comment)
        {
            var post = new CommentData
            {
                PostComment = comment,
                Status = _service.GetStatusById(statusId)
            };

            _service.SaveComment(post);

            return RedirectToAction("Index", "Wall");
        }
    }
}