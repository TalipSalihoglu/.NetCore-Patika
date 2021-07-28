using FluentValidation;

namespace Webapi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator:AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(Commands=>Commands.DirectorId).GreaterThan(0);
        }
    }
}
