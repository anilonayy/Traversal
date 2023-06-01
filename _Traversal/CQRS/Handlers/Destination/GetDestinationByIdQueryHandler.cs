using _Traversal.CQRS.Queries.Destination;
using _Traversal.CQRS.Results.Destination;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace _Traversal.CQRS.Handlers.Destination
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinatons.Find(query.id);

            return new GetDestinationByIdQueryResult
            {
                city = values.City,
                daynight = values.DayNight,
                DestinationId = values.DestinationId,
                price = values.Price
            };
        }


    }
}
