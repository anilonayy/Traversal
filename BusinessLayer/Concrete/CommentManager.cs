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


    public class CommentManager : ICommentService
    {
        ICommentDal CommentDal;

        public CommentManager()
        {
        }

        public CommentManager(ICommentDal _CommentDal)
        {
            CommentDal = _CommentDal;
        }

        public List<Comment> GetCommentsWithUserAndDestination(int destinationId)
        {
            return CommentDal.GetCommentsWithUserAndDestination(destinationId);
        }
        public List<Comment> GetCommentsWithUserAndDestination()
        {
            return CommentDal.GetCommentsWithUserAndDestination();
        }

        public void TAdd(Comment t)
        {
            CommentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            CommentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return CommentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
            return CommentDal.GetList();
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
        {
            return CommentDal.GetListByFilter(filter);
        }
        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> include)
        {
            return CommentDal.GetListByFilter(filter,include);
        }

     

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
