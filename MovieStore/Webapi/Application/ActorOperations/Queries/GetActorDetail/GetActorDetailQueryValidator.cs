using FluentValidation;

namespace Webapi.Application.ActorOperations.Commands.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator:AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(Commands=>Commands.ActorId).GreaterThan(0);
        }
    }
}