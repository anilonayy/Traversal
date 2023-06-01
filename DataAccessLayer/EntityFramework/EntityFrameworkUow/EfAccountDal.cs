using DataAccessLayer.Abstract.AbstractUow;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository.UowRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework.EntityFrameworkUow
{
    public class EfAccountDal : GenericUowRepository<Account>, IAccountDal
    {

        public EfAccountDal(Context context) : base(context) { }
        
    }
}
