using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public  interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListByFilter(Expression<Func<Comment, bool>> filter);
        public List<Comment> GetListByFilter(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> include);

        public List<Comment> GetCommentsWithUserAndDestination(int destinationId);
        public List<Comment> GetCommentsWithUserAndDestination();
    }
}
