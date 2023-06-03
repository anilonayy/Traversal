using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        public List<Comment> GetComments(int userId);
    }
}
