using BusinessLayer.Models;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class ContactUsValidator : AbstractValidator<AddContactUsDTO>
    {
        public ContactUsValidator()
        {
            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Lütfen E-Mail Adresi Girin.")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir E-Mail Adresi Girin.");

            RuleFor(x => x.MessageBody)
                .MaximumLength(500).WithMessage("En fazla 500 karakter girebillirsiniz.")
                .MinimumLength(10).WithMessage("En Az 10 Karakter Girebilirsiniz")
                .NotEmpty().WithMessage("Lütfen Bir Mesaj Girin.");

            RuleFor(x => x.Subject)
                .MaximumLength(100).WithMessage("En fazla 100 karakter girebillirsiniz.")
                .MinimumLength(5).WithMessage("En Az 5 Karakter Girebilirsiniz")
                .NotEmpty().WithMessage("Lütfen Bir Konu Girin.");

            RuleFor(x => x.Name)
               .MaximumLength(80).WithMessage("En fazla 80 karakter girebillirsiniz.")
               .MinimumLength(3).WithMessage("En Az 3 Karakter Girebilirsiniz")
               .NotEmpty().WithMessage("Lütfen Bir İsim Girin.");
        }
    }
}
