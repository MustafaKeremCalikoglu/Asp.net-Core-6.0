using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.ViewComponents.Default
{
    public class _SubAbout:ViewComponent
    {   

        SubAboutManager _subAboutManager=new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var result=_subAboutManager.GetAll();
            return View(result);
        }
    }
}
