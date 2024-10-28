using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManger = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;
        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var result = _destinationManger.GetAll();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {

            if (User.Identity.IsAuthenticated)
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userID = value.Id;
                ViewBag.a = "gir";
            }
            ViewBag.i = id;
            ViewBag.destID = id;
            var values = _destinationManger.TGetDestinationListWithGuide(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {

            return View();
        }
    }
}
