using _Traversal.Areas.Member.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{

    public class CommentController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, IAppUserService appUserManager, ICommentService commentService)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
            _commentService = commentService;
        }

        public async Task <IActionResult> Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb
            {
                HasSubTitle = true,
                Title = "Yorumlarım",
                SubTitle = "Yorumlarım"


            };
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var comments = _appUserManager.TGetComments(user.Id);

            return View(comments);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            _commentService.TDelete(_commentService.TGetById(id));

            return RedirectToAction("Index");
        }
    }
}
