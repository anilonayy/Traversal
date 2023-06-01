using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class AppUserRegisterValidator :AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail  Alanı Boş Geçilemez");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz.");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.Password).Equal(y => y.ConfrimPassword).WithMessage("Şifreler Eşleşmiyor!");
            RuleFor(x => x.ConfrimPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez.");

        }
    }
}
