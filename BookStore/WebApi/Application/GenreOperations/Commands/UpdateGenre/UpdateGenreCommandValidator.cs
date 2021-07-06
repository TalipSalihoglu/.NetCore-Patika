using System.Linq;
using System;
using WebApi.DbOperations;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator: AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim()!=string.Empty);
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}