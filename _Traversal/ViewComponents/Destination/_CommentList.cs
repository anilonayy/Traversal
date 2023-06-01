using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _CommentList :  ViewComponent
    {
        ICommentService _service;

        public _CommentList(ICommentService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke(int DestinationId)
        {

            var list = _service.TGetListByFilter(x => x.DestinationId == DestinationId, x => x.AppUser);
            return View(list);
        }
    }
}
