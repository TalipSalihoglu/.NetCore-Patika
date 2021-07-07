using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.LastName).NotEmpty().MinimumLength(3);
        }
    }
}