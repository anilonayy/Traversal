using _Traversal.CQRS.Results.Guide;
using MediatR;

namespace _Traversal.CQRS.Queries.Guide
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public int GuideId { get; set; }

        public GetGuideByIdQuery(int id)
        {
            GuideId = id;
        }
    }
}
