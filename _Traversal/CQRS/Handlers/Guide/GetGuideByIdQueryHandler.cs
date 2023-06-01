using _Traversal.CQRS.Queries.Guide;
using _Traversal.CQRS.Results.Guide;
using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace _Traversal.CQRS.Handlers.Guide
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context) {

            _context = context;

        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Guides.FindAsync(request.GuideId);

            return new GetGuideByIdQueryResult
            {
                GuideId  = data.GuideId,
                Description = data.Description,
                Image = data.Image,
                Name = data.Name
            };

           
        }
    }
}
