using Microsoft.AspNet.Identity;
using ParrisConnection.ServiceLayer.Data;
using ParrisConnection.ServiceLayer.Services.Comments.Save;
using ParrisConnection.ServiceLayer.Services.Wall;
using System.Web.Http;
using System.Web.Mvc;

namespace ParrisConnection.Controllers
{
    [System.Web.Mvc.Authorize]
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
            return View();
        }

        public JsonResult Status()
        {
            var wall = _service.GetWallData();

            return Json(wall, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreateComment([FromBody] StatusData status)
        {
            if (User == null) return RedirectToAction("Index", "Wall");

            var post = new CommentData
            {
                UserId = User.Identity.GetUserId(),
                PostComment = status.NewComment
            };

            _commentSaveService.SaveComment(post, status.Id);


            return RedirectToAction("Index", "Wall");
        }
    }
}