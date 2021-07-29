using FluentValidation;

namespace Webapi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(Commands=>Commands.Model.Name).MinimumLength(3);
            RuleFor(Commands=>Commands.Model.LastName).MinimumLength(3);
        }
    }
}