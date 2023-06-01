using EntityLayer.Concrete;

namespace _Traversal.CQRS.Commands.Destination
{
    public class CreateDestinationCommand
    {
        public string? City { get; set; }
        public string? DayNight { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }

    }
}
