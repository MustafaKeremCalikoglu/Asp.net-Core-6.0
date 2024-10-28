using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    [Authorize(Roles = "admin")]


    public class ContactUsController : Controller
    {

        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactUsService.GetAll();
            return View(values);
        }
        [Route("UpdateMessage/{id}")]
        public IActionResult UpdateMessage(int id)
        {
            _contactUsService.TContactUsStatusChangeToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
