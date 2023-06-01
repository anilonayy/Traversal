namespace _Traversal.CQRS.Results.Destination
{
    public class GetDestinationByIdQueryResult
    {
        public int DestinationId { get; set; } 
        public string city { get; set; } 
        public string daynight { get; set; }
        public decimal price { get; set; }
    }
}
