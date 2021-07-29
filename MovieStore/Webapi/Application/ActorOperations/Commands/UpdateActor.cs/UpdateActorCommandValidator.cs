using System;
using FluentValidation;

namespace Webapi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {   
            RuleFor(command=>command.Model.Name).MinimumLength(3);
            RuleFor(command=>command.Model.LastName).MinimumLength(3);
            RuleFor(command=>command.ActorId).GreaterThan(0);
        }
    }
}