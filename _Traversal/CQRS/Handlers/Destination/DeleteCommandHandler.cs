using _Traversal.CQRS.Commands.Destination;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;

namespace _Traversal.CQRS.Handlers.Destination
{
    public class DeleteCommandHandler
    {
        private readonly Context _context;

        public DeleteCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handler( DeleteDestinationCommand command)
        {
            var target = new EntityLayer.Concrete.Destination() { DestinationId = command.id };

            _context.Destinatons.Remove(target);
            _context.SaveChanges();
        }
    }
}
