using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(Company => Company.Name).NotEmpty().WithMessage("Lütfen şirket ismi belirtiniz.");
            RuleFor(Company => Company.TaxNumber)
                .NotEmpty()
                .WithMessage("Lütfen vergi numarası giriniz.")
                .Length(10);


        }


    }
}
