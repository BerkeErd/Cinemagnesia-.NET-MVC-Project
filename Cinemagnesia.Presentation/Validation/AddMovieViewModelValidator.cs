using Cinemagnesia.Presentation.Models;
using FluentValidation;

namespace Cinemagnesia.Presentation.Validation
{
    public class AddMovieViewModelValidator : AbstractValidator<AddMovieViewModel>
    {
        public AddMovieViewModelValidator()
        {
            RuleFor(vm => vm.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            RuleFor(vm => vm.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(vm => vm.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(vm => vm.PosterPath).NotEmpty().WithMessage("PosterPath is required.");
            RuleFor(vm => vm.ReleaseDate).NotEmpty().WithMessage("ReleaseDate is required.");
            RuleFor(vm => vm.ImdbRating).InclusiveBetween(0, 10).WithMessage("ImdbRating must be between 0 and 10.");
            RuleFor(vm => vm.TrailerUrl).NotEmpty().WithMessage("TrailerUrl is required.");
            RuleFor(vm => vm.Directors).NotEmpty().WithMessage("At least one director is required.");
            RuleForEach(vm => vm.Directors).SetValidator(new AddDirectorViewModelValidator());
            RuleFor(vm => vm.Genres).NotEmpty().WithMessage("At least one genre is required.");
            RuleForEach(vm => vm.Genres).SetValidator(new AddGenreToMovieViewModelValidator());
            RuleFor(vm => vm.CastMembers).NotEmpty().WithMessage("At least one cast member is required.");
            RuleForEach(vm => vm.CastMembers).SetValidator(new AddCastMemberViewModelValidator());
            RuleFor(vm => vm.MovieMinutes).GreaterThan(0).WithMessage("MovieMinute must be greater than 0.");
            RuleFor(vm => vm.Language).NotEmpty().WithMessage("Language is required.");
        }
    }
}

