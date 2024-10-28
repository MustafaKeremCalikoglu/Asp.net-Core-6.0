using AutoMapper;
using BusinessLayer.ValidationRules;
using DTOLayer.AnnoucementDTOs;
using DTOLayer.AppUserDTOs;
using DTOLayer.CityDTOs;
using DTOLayer.ContactDTOs;
using EntityLayer.Concrete;

namespace TravelCore.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnoucementAddDTOs,Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDTOs,AppUser>().ReverseMap();

            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDTOs, AppUser>().ReverseMap();


            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();



        }
    }
}
