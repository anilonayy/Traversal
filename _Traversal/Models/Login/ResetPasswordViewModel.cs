using System.ComponentModel.DataAnnotations;

namespace _Traversal.Models.Login
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage="Şifre alanı zorunludur.")]
        [MinLength(3,ErrorMessage ="En az 3 karakter olmalıdır")]
        [MaxLength(16,ErrorMessage ="En fazla 16 karakter olmalıdır")]

        public string? Password { get; set; }
		[Required(ErrorMessage = "Şifre Onay alanı zorunludur.")]
		[MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
		[MaxLength(16, ErrorMessage = "En fazla 16 karakter olmalıdır")]
        [Compare("Password",ErrorMessage ="Şifreler aynı olmalıdır!")]
		public string? RePassword { get; set; }
    }
}
