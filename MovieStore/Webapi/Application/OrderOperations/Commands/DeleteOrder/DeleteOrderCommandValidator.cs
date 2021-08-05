
using FluentValidation;

namespace Webapi.Application.OrderOpearations.Commands.DeleteOrder{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>{
        public DeleteOrderCommandValidator()
        {
            RuleFor(x=>x.OrderId).GreaterThan(0);
        }
    }
}