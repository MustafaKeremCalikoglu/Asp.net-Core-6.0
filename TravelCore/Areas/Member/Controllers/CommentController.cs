using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Member.Controllers
{
    [Area("Member")]
    
    public class CommentController : Controller
    {
        
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
