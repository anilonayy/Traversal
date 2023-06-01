namespace _Traversal.CQRS.Commands.Destination
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
