
using _Traversal.Areas.Admin.Models.ViewModels;
using AutoMapper;
using EntityLayer.Concrete;

namespace _Traversal.Areas.Admin.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Destination, DestinationAddFormViewModel>().ReverseMap();
            CreateMap<Destination, DestinationUpdateFormViewModel>().ReverseMap();
        }
    }
}

