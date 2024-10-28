using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    [Authorize(Roles = "admin")]

    public class DestinationController : Controller
    {

        private readonly IDestinationService _destinationService;    
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var result = _destinationService.GetAll();
            return View(result);
        }

        [HttpGet]
        [Route("AddDestination")]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        [Route("AddDestination")]
        public IActionResult AddDestination(Destination p)
        {
            _destinationService.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateDestination/{id}")]

        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateDestination/{id}")]

        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUptade(p);
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            _destinationService.TRemove(value);
            return RedirectToAction("Index");
        }
    }

}
