using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.ViewComponents.Default
{
    public class _PopularDestinations:ViewComponent
    {

        DestinationManager destinationManger = new DestinationManager(new EfDestinationDal());

        public IViewComponentResult Invoke()
        {
            var result = destinationManger.GetAll();
            return View(result);
        }
    }
}
