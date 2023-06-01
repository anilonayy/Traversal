using _Traversal.CQRS.Commands.Guide;
using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace _Traversal.CQRS.Handlers.Guide
{
    public class DeleteGuideCommandHandler : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public Task Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Here is worked");
            var target  = _context.Guides.Find(request.GuideId);
            _context.Guides.Remove(target);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
