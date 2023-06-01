using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TAdd(Reservation t) => _reservationDal.Insert(t);
        

        public void TDelete(Reservation t) => _reservationDal.Delete(t);

        public Reservation TGetById(int id) =>  _reservationDal.GetById(id);
       

        public List<Reservation> TGetList() =>  _reservationDal.GetList();
      

        public void TUpdate(Reservation t) => _reservationDal.Update(t);


        public List<Reservation> TGetListByFilter(Expression<Func<Reservation,bool>> filter) => _reservationDal.GetListByFilter(filter);

        public List<Reservation> TGetListByFilter(Expression<Func<Reservation, bool>> filter,Expression<Func<Reservation,object>> include) =>   _reservationDal.GetListByFilter(filter, include);

        public List<Reservation> TGetListByApprovalReservations(int id) => _reservationDal.GetListByApprovalReservations(id);
    

        public List<Reservation> TGetListByAcceptedReservations(int id) => _reservationDal.GetListByAcceptedReservations(id);


        public List<Reservation> TGetListByRejectedReservations(int id) => _reservationDal.GetListByRejectedReservations(id);


        public List<Reservation> TGetListByPreviousReservations(int id) => _reservationDal.GetListByPreviousReservations(id);

    }
}
