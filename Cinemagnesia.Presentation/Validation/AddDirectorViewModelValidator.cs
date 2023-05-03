using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Cinemagnesia.Presentation.Validation
{
    public class AddDirectorViewModelValidator : AbstractValidator<AddDirectorViewModel>
    {
        public AddDirectorViewModelValidator()
        {
            RuleFor(vm => vm.Name).NotEmpty().WithMessage("Director name is required.");
        }
    }
}
