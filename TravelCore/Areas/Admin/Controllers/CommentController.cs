using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    [Authorize(Roles = "admin")]

    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var result = _commentService.TGetGetListCommentWithDestiantion();
            return View(result);
        }
        [Route("DeleteComment/{id}")]

        public IActionResult DeleteComment(int id)
        {
            var result = _commentService.TGetById(id);
            _commentService.TRemove(result);
            return RedirectToAction("Index");
        }
    }
}
