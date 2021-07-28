using System;
using FluentValidation;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;

namespace Webapi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {   
            RuleFor(command=>command.Model.DirectorId).GreaterThan(0);
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command=>command.Model.Name).MinimumLength(2);
            RuleFor(command=>command.Model.Price).GreaterThan(0);
            RuleFor(command=>command.MovieId).GreaterThan(0);
        }
    }
}