using Cinemagnesia.Domain.Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
            RuleFor(ApplicationUser => ApplicationUser.FirstName).NotEmpty().WithMessage("{PropertyName} alanı boş olamaz.");
            RuleFor(ApplicationUser => ApplicationUser.LastName).NotEmpty().WithMessage("{PropertyName} alanı boş olamaz.");
            RuleFor(ApplicationUser => ApplicationUser.Birthday).NotEmpty().WithMessage("{PropertyName} alanı boş olamaz.");

        }
    }
}
