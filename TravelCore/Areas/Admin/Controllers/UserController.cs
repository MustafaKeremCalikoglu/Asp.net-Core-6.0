using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]


    public class UserController : Controller
    {

        IAppUserService _userService;
        IReservationService _reservationService;
        public UserController(IAppUserService userService,IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var result = _userService.GetAll();
            return View(result);
        }
        public IActionResult DeleteUser(int id)
        {
            return RedirectToAction("Index");
        }
       

        public IActionResult CommentUser(int id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult ReservationUser(int id)
        {   
            var values=_reservationService.GetListWithReservationByPrevious(id);
            return View(values);
        }


    }
}
