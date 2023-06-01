using _Traversal.CQRS.Commands.Guide;
using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;

namespace _Traversal.CQRS.Handlers.Guide
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public Task Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var target =_context.Guides.Find(request.GuideId);
            target.Image = request.Image;
            target.Description = request.Description;
            target.Name = request.Name;
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
