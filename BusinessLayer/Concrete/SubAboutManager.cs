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
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _sub;

        public SubAboutManager(ISubAboutDal sub)
        {
            _sub = sub;
        }

        public void TAdd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public SubAbout TGetById(int id)
        {
            return _sub.GetById(id);
        }

        public List<SubAbout> TGetList()
        {
            return _sub.GetList();
        }

        public List<SubAbout> TGetListByFilter(Expression<Func<SubAbout, bool>> func)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
