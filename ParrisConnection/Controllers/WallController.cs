using ParrisConnection.DataLayer.DataAccess;
using ParrisConnection.DataLayer.Entities;
using ParrisConnection.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Comment = ParrisConnection.DataLayer.Entities.Wall.Comment;

namespace ParrisConnection.Controllers
{
    public class WallController : Controller
    {
        private DataAccess _context;

        public WallController()
        {
           _context = new DataAccess(new ParrisDbContext());
        }

        public ActionResult Index()
        {
            var wall = new WallViewModel
            {
                Statuses = _context.Statuses.GetAll().ToList()
            };

            return View(wall);
        }

        [HttpPost]
        public ActionResult CreateComment(int statusId, string comment)
        {
            var post = new Comment
            {
                PostComment = comment,
                Status = _context.Statuses.GetById(statusId)
            };

            _context.Comments.Insert(post);
                    
            return RedirectToAction("Index", "Wall");
        }
    }
}