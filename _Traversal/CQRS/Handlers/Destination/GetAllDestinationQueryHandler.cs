using _Traversal.CQRS.Queries.Destination;
using _Traversal.CQRS.Results.Destination;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace _Traversal.CQRS.Handlers.Destination
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context
                .Destinatons
                .Select(p => new GetAllDestinationQueryResult
                {
                    capacity = p.Capacity,
                    city = p.City,
                    daynight = p.DayNight,
                    id = p.DestinationId,
                    price = p.Price
                })
                .AsNoTracking()
                .ToList();

            return values;
            
        }
    }
}
