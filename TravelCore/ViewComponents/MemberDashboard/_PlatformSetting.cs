using Microsoft.AspNetCore.Mvc;

namespace TravelCore.ViewComponents.MemberDashboard
{
    public class _PlatformSetting:ViewComponent
    {  
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
