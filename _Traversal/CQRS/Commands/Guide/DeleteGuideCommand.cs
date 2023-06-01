using MediatR;

namespace _Traversal.CQRS.Commands.Guide
{
    public class DeleteGuideCommand : IRequest
    {
        public int GuideId { get; set; }

        public DeleteGuideCommand(int id)
        {
            GuideId = id;
        }

    }
}
