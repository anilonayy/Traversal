using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor
                (x => x.Description)
                .NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.")
                .MinimumLength(50).WithMessage("En az 50 karakter girilmelidir.")
                .MaximumLength(1500).WithMessage("En fazla 1500 karakter girilebilir.");


            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
        }
    }
}
