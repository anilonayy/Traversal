using AutoMapper;

using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;

namespace _Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddContactUsDTO, ContactUs>().ReverseMap();
        }
    }
}
