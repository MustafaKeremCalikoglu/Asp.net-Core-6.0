using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace TravelCore.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.NewsLetters.Count();
            ViewBag.v3 = c.Guides.Count();


            return View();
        }
    }
}
