using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Cinemagnesia.Presentation.Validation
{
    public class AddGenreToMovieViewModelValidator : AbstractValidator<AddGenreToMovieViewModel>
    {
        public AddGenreToMovieViewModelValidator()
        {
            RuleFor(vm => vm.Name).NotEmpty().WithMessage("Genre name is required.");

        }
    }
}