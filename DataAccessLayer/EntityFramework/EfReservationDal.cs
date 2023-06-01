using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListByApprovalReservations(int id) => GetListByFilter(x => x.AppUserId == id && x.Status == "Onay Bekliyor", x => x.Destination);


        public List<Reservation> GetListByAcceptedReservations(int id) => GetListByFilter(x => x.AppUserId == id && x.Status == "Onaylandı", x => x.Destination);


        public List<Reservation> GetListByRejectedReservations(int id) => GetListByFilter(x => x.AppUserId == id && x.Status == "Onaylanmadı", x => x.Destination);


        public List<Reservation> GetListByPreviousReservations(int id) => GetListByFilter(x => x.AppUserId == id && x.Status == "Geçmiş Rezervasyon", x => x.Destination);
    }
}
