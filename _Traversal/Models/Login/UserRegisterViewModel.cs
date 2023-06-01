using System.ComponentModel.DataAnnotations;

namespace Traversal.Models.Login
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Ad Alanı Doldurulması Zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Doldurulması Zorunludur")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Doldurulması Zorunludur")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email Alanı Doldurulması Zorunludur")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-mail girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Doldurulması Zorunludur")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Doldurulması Zorunludur")]
        [Compare("Password", ErrorMessage ="Şifreler Uyumlu Değil!")]
        public string ConfrimPassword { get; set; }
    }
}
