using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Cinemagnesia.Presentation.Validation
{
    public class AddCastMemberViewModelValidator : AbstractValidator<AddCastMemberViewModel>
    {
        public AddCastMemberViewModelValidator()
        {
            RuleFor(vm => vm.Name).NotEmpty().WithMessage("Cast member name is required.");

        }
    }
}