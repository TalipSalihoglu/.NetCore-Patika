using FluentValidation;

namespace Webapi.Application.OrderOpearations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>{
        public UpdateOrderCommandValidator()
        {
            RuleFor(x=>x.OrderId).GreaterThan(0);
            RuleFor(x=>x.Model.CustomerId).GreaterThan(0);
        }
    }
}

