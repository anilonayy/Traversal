using _Traversal.CQRS.Queries.Guide;
using _Traversal.CQRS.Results.Guide;
using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _Traversal.CQRS.Handlers.Guide
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult()
            {
                Description = x.Description,
                GuideId = x.GuideId,
                Image = x.Image,
                Name = x.Name
            })
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
