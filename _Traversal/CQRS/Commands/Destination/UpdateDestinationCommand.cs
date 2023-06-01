namespace _Traversal.CQRS.Commands.Destination
{
    public class UpdateDestinationCommand
    {
        public int DestinationId { get; set; }
        public string city { get; set; }
        public string daynight { get; set; }
        public decimal price { get; set; }
    }
}
