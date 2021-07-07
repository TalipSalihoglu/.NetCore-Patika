using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).MinimumLength(3);
            RuleFor(command=>command.Model.LastName).MinimumLength(3);
            RuleFor(command=>command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}