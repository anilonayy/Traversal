using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;


namespace BusinessLayer.ValidationRule.Announcements
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
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
