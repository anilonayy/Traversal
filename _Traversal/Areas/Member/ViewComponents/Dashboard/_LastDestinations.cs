using _Traversal.Areas.Member.Models.Dashboard;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Dashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public _LastDestinations(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var DestValues = _destinationService.TGetLast4DestinationsWithGuides();

            var sendValues = _mapper.Map<List<DashboardLastDestinationsViewModel>>(DestValues);

            return  View(sendValues);
        }
    }
}
