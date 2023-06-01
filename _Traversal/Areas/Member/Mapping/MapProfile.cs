using _Traversal.Areas.Member.Models.Dashboard;
using AutoMapper;
using EntityLayer.Concrete;

namespace _Traversal.Areas.Member.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Destination, DashboardLastDestinationsViewModel>().ReverseMap();
        }
    }
}
