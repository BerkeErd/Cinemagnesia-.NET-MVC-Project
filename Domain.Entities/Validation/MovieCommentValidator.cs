using Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Validation
{
    internal class MovieCommentValidator : AbstractValidator<MovieComment>
    {
        public MovieCommentValidator()
        {
            RuleFor(MovieComment => MovieComment.CommentText)
                 .NotEmpty()
                 .Length(20000)
                 .WithMessage("{PropertyName} alanı boş olamaz.");
        }
    }
}
