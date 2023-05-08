using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(Company => Company.Name).NotEmpty().MaximumLength(60);
            RuleFor(company => company.TaxNumber)
            .NotEmpty()
            .Length(10)
            .Matches("^[0-9]{10}$")
            .WithMessage("Vergi numarası tam olarak 10 rakamdan oluşmalıdır.");


            RuleFor(company => company.FoundDate)
            .NotEmpty()
            .Must(date => date <= DateTime.Today)
            .WithMessage("Kuruluş tarihi bugünden sonraki bir tarih olamaz.");
        }


    }
}
