using FluentValidation;

namespace Webapi.Application.DirectorOperations.Commands.DeleteDirector{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>{
        public DeleteDirectorCommandValidator()
        {
            RuleFor(Commands=>Commands.DirectorId).NotEmpty().GreaterThan(0);
        }        
    }
    
}