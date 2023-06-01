using EntityLayer.Concrete;

namespace _Traversal.Areas.Member.Models.Dashboard
{
    public class DashboardLastDestinationsViewModel
    {
        public int DestinationId { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }

        public int? GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
