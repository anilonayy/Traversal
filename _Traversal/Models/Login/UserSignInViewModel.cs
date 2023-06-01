using System.ComponentModel.DataAnnotations;

namespace _Traversal.Models.Login
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage="Kullanıcı Adı Boş Olamaz")]
        public string Username{ get; set; }
        [Required(ErrorMessage ="Şifre Boş Olamaz")]
        public string Password{ get; set; }
    }
}
