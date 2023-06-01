using _Traversal.CQRS.Commands.Destination;
using DataAccessLayer.Concrete;

namespace _Traversal.CQRS.Handlers.Destination
{
    public class UpdateCommandHandler
    {
        private readonly Context _context;

        public UpdateCommandHandler(Context context)
        {
            _context = context;
        }


        public void Handle(UpdateDestinationCommand model)
        {

            var target = _context.Destinatons.Find(model.DestinationId);
            target.City = model.city;
            target.DayNight = model.daynight;
            target.Price = model.price;
            _context.SaveChanges();
        }
    }
}
