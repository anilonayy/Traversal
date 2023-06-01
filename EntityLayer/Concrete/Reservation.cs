using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
