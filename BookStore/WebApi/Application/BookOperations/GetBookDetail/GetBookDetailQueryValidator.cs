using FluentValidation;
using WebApi.Application.BookOperations.GetBookDetail;

namespace WebApi.Application.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(common=>common.BookId).GreaterThan(0);
        }
    }
}