using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class CommentController : Controller
    {
       

        ICommentService comment;
        UserManager<AppUser> userManager;
    
        public CommentController(ICommentService _comment,UserManager<AppUser> AppUserManager)
        {
            comment = _comment;
            userManager = AppUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Comment c)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            c.AppUserId = user.Id;

            comment.TAdd(c);
            return RedirectToAction("Detail", "Destination",new {id =c.DestinationId});  
        }

    

    }
}
