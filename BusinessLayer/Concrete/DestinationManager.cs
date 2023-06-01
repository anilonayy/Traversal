using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;

        }

        public Destination TGetDestinaitonWithGuide(int id)
        {
            return _destinationDal.GetDestinaitonWithGuide(id);
        }

        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public List<Destination> TGetListByFilter(Expression<Func<Destination, bool>> func)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }

        public List<Destination> TGetLast4DestinationsWithGuides()
        {
            return _destinationDal.GetLast4DestinationsWithGuides();
        }
    }
}
