using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using ParrisConnection.ViewModels;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    public class WallController : Controller
    {
        private readonly IStatusService _statusService;

        public WallController(IStatusService statusService)
        {
           _statusService = statusService;
        }

        public ActionResult Index()
        {
            var wall = new WallViewModel
            {
                Statuses = _statusService.GetStatuses()
            };

            return View(wall);
        }

        [HttpPost]
        public ActionResult CreateComment(int statusId, string comment)
        {
            var post = new CommentData
            {
                PostComment = comment,
                Status = _statusService.GetStatusById(statusId)
            };

            //_context.Comments.Insert(post);

            return RedirectToAction("Index", "Wall");
        }
    }
}