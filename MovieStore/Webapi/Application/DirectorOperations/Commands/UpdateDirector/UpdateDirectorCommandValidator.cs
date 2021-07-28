using FluentValidation;

namespace Webapi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {       
        public UpdateDirectorCommandValidator()
        {   
            RuleFor(Commands=>Commands.DirectorId).GreaterThan(0);
            RuleFor(Commands=>Commands.Model.LastName).MinimumLength(3);
            RuleFor(Commands=>Commands.Model.Name).MinimumLength(3);
        }
    }   
}