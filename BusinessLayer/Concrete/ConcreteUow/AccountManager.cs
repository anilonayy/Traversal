using BusinessLayer.Abstract.AbstractUow;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.AbstractUow;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUow
{
    public class AccountManager : IGenericUowService<Account> , IAccountService
    {
        private readonly IAccountDal _service;
        private readonly IUowDal _uowDal;

        public AccountManager(IAccountDal service, IUowDal uowDal) 
        {
            _service = service;
            _uowDal = uowDal;
        }


        public Account TGetById(int id)
        {
            return _service.GetById(id);
        }
        public void TInsert(Account t)
        {
            _service.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _service.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _service.Update(t);
            _uowDal.Save();
        }
    }

    
}
