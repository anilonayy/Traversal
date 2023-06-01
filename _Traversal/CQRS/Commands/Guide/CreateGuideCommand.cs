using MediatR;

namespace _Traversal.CQRS.Commands.Guide
{
    public class CreateGuideCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
