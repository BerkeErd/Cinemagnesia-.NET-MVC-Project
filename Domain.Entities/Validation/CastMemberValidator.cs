using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class CastMemberValidator : AbstractValidator<CastMember>
    {
        public CastMemberValidator() {
            RuleFor(CastMember => CastMember.Name).NotEmpty().WithMessage("{PropertyName} alanı boş olamaz.");
        
        }
    }
}
