using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> TGetListByApprovalReservations(int id);
        List<Reservation> TGetListByAcceptedReservations(int id);
        List<Reservation> TGetListByRejectedReservations(int id);
        List<Reservation> TGetListByPreviousReservations(int id);
    }
}
