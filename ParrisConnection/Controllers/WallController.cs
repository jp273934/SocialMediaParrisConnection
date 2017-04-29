using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    [Authorize]
    public class WallController : Controller
    {

        private readonly IWallService _service;

        public WallController(IWallService service)
        {
           _service  = service;
        }

        public ActionResult Index()
        {
            var wall = _service.GetWallData();

            return View(wall);
        }

        [HttpPost]
        public ActionResult CreateComment(int statusId, string comment)
        {
            var post = new CommentData
            {
                UserId = User.Identity.GetUserId(),
                PostComment = comment,               
            };

            _service.SaveComment(post, statusId);

            return RedirectToAction("Index", "Wall");
        }
    }
}