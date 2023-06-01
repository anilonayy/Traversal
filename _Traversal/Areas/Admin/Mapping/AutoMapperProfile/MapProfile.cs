using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using EntityLayer.Concrete;

namespace _Traversal.Areas.Admin.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();

            CreateMap<CityAddDTO, Destination>().ReverseMap();

            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();

            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();


        }
    }
}
