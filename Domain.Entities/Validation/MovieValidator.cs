using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(Movie => Movie.Title)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .WithMessage("{PropertyName} alanı boş olamaz.");

            RuleFor(Movie => Movie.Description)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("{PropertyName} alanı boş olamaz.");

            RuleFor(Movie => Movie.ReleaseDate)
                .NotEmpty()
                .WithMessage("{PropertyName} alanı boş olamaz.");

            RuleFor(Movie => Movie.CastMembers)
                .NotEmpty()
                .WithMessage("{PropertyName} alanı boş olamaz.");

            RuleFor(Movie => Movie.CinemagAvgScore)
               .InclusiveBetween(0, 10).WithMessage("{PropertyName} alanı {From} ile {To} arasında olmalıdır.")
               .NotEmpty()
               .WithMessage("{PropertyName} alanı boş olamaz.");




        }
    }
}
