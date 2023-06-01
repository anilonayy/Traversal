using _Traversal.CQRS.Commands.Guide;
using DataAccessLayer.Concrete;
using MediatR;

namespace _Traversal.CQRS.Handlers.Guide
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public Task Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Description = request.Description,
                Image = request.Image,
                Name = request.Name,
                InstagramUrl = "Empty",
                TwitterUrl = "Empty",
                Status = true
            });

            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
