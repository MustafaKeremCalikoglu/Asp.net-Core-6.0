using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Member.Controllers
{
    [Area("Member")]
    
    

    public class DestinationController : Controller
    {
       
        DestinationManager destinationManger = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {

            var result = destinationManger.GetAll();
            return View(result);
        }
    }
}
