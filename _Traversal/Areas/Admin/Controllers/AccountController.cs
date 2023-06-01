using _Traversal.Areas.Admin.Models.ViewModels;
using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _AccountService;

        public AccountController(IAccountService accountService)
        {
            _AccountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountCreateViewModel p)
        {
            var sender = _AccountService.TGetById(p.SenderId);
            var receiver = _AccountService.TGetById(p.ReceiverId);

            sender.Balance -= p.Amount;
            receiver.Balance += p.Amount;

            List<Account> updateList = new List<Account>() { sender, receiver };

            _AccountService.TMultiUpdate(updateList);

            return View();
        }
    }
}
