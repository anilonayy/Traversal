using MediatR;

namespace _Traversal.CQRS.Commands.Guide
{
    public class UpdateGuideCommand : IRequest
    {
        public int GuideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
