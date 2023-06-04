using _Traversal.Areas.Member.Models.Dashboard;
using AutoMapper;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;

namespace _Traversal.Areas.Member.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Destination, DashboardLastDestinationsViewModel>().ReverseMap();
            CreateMap<Destination, GetCityByNameResultDTO>();
        }
    }
}
