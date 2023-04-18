using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class CompanyUserValidator : AbstractValidator<CompanyUser>
    {
        public CompanyUserValidator()
        {
            RuleFor(CompanyUser => CompanyUser.ApplicationUserId)
                .NotEmpty()
                .WithMessage("{PropertyName} alanı boş olamaz.");
            RuleFor(CompanyUser => CompanyUser.CompanyId)
                .NotEmpty()
                .WithMessage("{PropertyName} alanı boş olamaz.");

        }
    }
}
