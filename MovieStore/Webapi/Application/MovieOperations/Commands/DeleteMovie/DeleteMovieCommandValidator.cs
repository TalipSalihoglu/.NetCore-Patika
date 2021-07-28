using FluentValidation;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;

namespace Webapi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command=>command.MovieId).NotNull().GreaterThan(0);
        }
    }
}