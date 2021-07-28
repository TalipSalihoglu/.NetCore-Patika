
using FluentValidation;

namespace Webapi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>{
        public CreateDirectorCommandValidator()
        {
            RuleFor(Commands=>Commands.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(Commands=>Commands.Model.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
