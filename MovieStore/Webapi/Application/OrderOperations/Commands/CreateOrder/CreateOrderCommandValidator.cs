using FluentValidation;

namespace Webapi.Application.OrderOpearations.Commands.CreateOrder{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>{
        public CreateOrderCommandValidator()
        {
            RuleFor(Commands=>Commands.Model.MovieId).GreaterThan(0);
            RuleFor(Commands=>Commands.Model.CustomerId).GreaterThan(0);
        }
    }
}