using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule.Announcements
{
    public class AnnouncementAddValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru adı boş olamaz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapınız!");

            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz!");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lütfen en az 20 karakter veri girişi yapınız!");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter veri girişi yapınız!");
        }
    }
}
