using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter);
        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> include);

        public List<Comment> GetCommentsWithUserAndDestination(int destinationId);
        public List<Comment> GetCommentsWithUserAndDestination();
    }
}
