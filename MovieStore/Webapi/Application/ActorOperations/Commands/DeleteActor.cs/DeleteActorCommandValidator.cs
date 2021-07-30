using FluentValidation;

namespace Webapi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator:AbstractValidator<DeleteActorCommand>{
        public DeleteActorCommandValidator()
        {
           RuleFor(Commands=>Commands.ActorId).GreaterThan(0);
        }
    }
}