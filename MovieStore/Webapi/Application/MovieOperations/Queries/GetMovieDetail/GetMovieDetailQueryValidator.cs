using FluentValidation;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;

namespace Webapi.Application.MovieOperations.Queries.GetMovieDetai
{
    public class GetMovieDetailQueryValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(command=>command.MovieId).NotNull().GreaterThan(0);
        }
    }
}