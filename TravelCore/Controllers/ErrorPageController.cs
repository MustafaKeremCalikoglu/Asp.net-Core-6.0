using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int id)
        {   

            return View();
        }
    }
}
