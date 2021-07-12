using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.model.GenreId).GreaterThan(0);
            RuleFor(command=>command.model.AuthorId).GreaterThan(0);
            RuleFor(command=>command.model.PageCount).GreaterThan(0);
            RuleFor(command=>command.model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.model.Title).NotEmpty().MinimumLength(4);
        }
    }
}