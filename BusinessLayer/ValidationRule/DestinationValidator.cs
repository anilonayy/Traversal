using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class DestinationValidator : AbstractValidator<Destination>
    {
        public DestinationValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir Adı boş olamaz.")
                .NotNull().WithMessage("Şehir Adı alanı gereklidir.");

            RuleFor(x => x.DayNight)
                .NotEmpty().WithMessage("Tur Süresi boş olamaz.")
                .NotNull().WithMessage("Tur Süresi alanı gereklidir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Tur Açıklaması boş olamaz.")
                .NotNull().WithMessage("Tur Açıklaması alanı gereklidir.");

            RuleFor(x => x.Description2)
                .NotEmpty().WithMessage("Tur Açıklaması 2 boş olamaz.")
                .NotNull().WithMessage("Tur Açıklaması 2 alanı gereklidir.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat boş olamaz.")
                .NotNull().WithMessage("Fiyat alanı gereklidir.")
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat alanı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CoverImage)
                .NotEmpty().WithMessage("Kapak Resmi boş olamaz.")
                .NotNull().WithMessage("Kapak Resmi alanı gereklidir.");

            RuleFor(x => x.Image1)
                .NotEmpty().WithMessage("İmaj 1 boş olamaz.")
                .NotNull().WithMessage("İmaj 1 alanı gereklidir.");

            RuleFor(x => x.Image2)
                .NotEmpty().WithMessage("İmaj 2 boş olamaz.")
                .NotNull().WithMessage("İmaj 2 alanı gereklidir.");
        }
    }
}
