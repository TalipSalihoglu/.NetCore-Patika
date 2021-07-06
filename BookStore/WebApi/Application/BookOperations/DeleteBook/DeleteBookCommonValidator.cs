using FluentValidation;

namespace WebApi.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(common=>common.BookId).NotEmpty().GreaterThan(0);
        }
    }
}