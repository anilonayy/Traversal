using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListByApprovalReservations(int id);
        List<Reservation> GetListByAcceptedReservations(int id);
        List<Reservation> GetListByRejectedReservations(int id);
        List<Reservation> GetListByPreviousReservations(int id);
    }
}
