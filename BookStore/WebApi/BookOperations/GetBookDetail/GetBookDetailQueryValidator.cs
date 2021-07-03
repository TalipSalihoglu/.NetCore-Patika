using FluentValidation;
using WebApi.BookOperations.GetBookDetail;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(common=>common.BookId).GreaterThan(0);
        }
    }
}