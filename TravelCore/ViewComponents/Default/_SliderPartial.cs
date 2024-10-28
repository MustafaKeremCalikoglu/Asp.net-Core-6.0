using Microsoft.AspNetCore.Mvc;

namespace TravelCore.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
