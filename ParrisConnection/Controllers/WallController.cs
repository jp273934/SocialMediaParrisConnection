using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Interfaces;
using System.Web.Mvc;
using ParrisConnection.ServiceLayer.Services.Comments.Save;

namespace ParrisConnection.Controllers
{
    [Authorize]
    public class WallController : Controller
    {

        private readonly IWallService _service;
        private readonly ICommentSaveService _commentSaveService;

        public WallController(IWallService service, ICommentSaveService commentSaveService)
        {
            _service  = service;
            _commentSaveService = commentSaveService;
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

            _commentSaveService.SaveComment(post, statusId);

            return RedirectToAction("Index", "Wall");
        }
    }
}