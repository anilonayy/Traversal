using _Traversal.CQRS.Commands.Destination;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;

namespace _Traversal.CQRS.Handlers.Destination
{
    public class CreateCommandHandler
    {
        private readonly Context _context;

        public CreateCommandHandler(Context context)
        {
            _context = context;
        }


        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinatons.Add(new EntityLayer.Concrete.Destination()
            {
                City = command.City,
                Capacity = command.Capacity,
                DayNight = command.DayNight,
                Status = true,
                Price = command.Price
            });

            _context.SaveChanges();
        }
    }
}
