using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> 
    {
        void TAdd(T t);
        void TUpdate(T t);
        void TDelete(T t);

        List<T> TGetList();
        List<T> TGetListByFilter(Expression<Func<T, bool>> func);
        T TGetById(int id);

    }
}
