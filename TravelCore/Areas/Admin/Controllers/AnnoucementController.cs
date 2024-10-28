using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.AnnoucementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Annoucement")]
    [Authorize(Roles ="admin")]
    public class AnnoucementController : Controller
    {

        private readonly IAnnouncementService _annoucementService;
        private readonly IMapper _mapper;
        public AnnoucementController(IAnnouncementService annoucementService, IMapper mapper)
        {
            _annoucementService = annoucementService;
            _mapper = mapper;
        }
        [Route("Index")]

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_annoucementService.GetAll());    
            return View(values);
        }

        [HttpGet]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement()
        {
            
            return View();
        }
        [HttpPost]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement(AnnoucementAddDTOs model)
        {

            if (ModelState.IsValid)
            {
                _annoucementService.TAdd(new Announcement()
                {
                    Content=model.Content,
                    Title=model.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _annoucementService.TGetById(id);
            _annoucementService.TRemove(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateAnnouncement/{id}")]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_annoucementService.TGetById(id));
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAnnouncement/{id}")]

        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _annoucementService.TUptade(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
