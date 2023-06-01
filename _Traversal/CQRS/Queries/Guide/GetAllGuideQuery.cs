using _Traversal.CQRS.Results.Guide;
using MediatR;

namespace _Traversal.CQRS.Queries.Guide
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
