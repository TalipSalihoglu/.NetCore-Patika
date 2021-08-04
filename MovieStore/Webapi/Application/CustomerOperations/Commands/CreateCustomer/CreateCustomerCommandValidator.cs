using FluentValidation;

namespace Webapi.Application.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>{
        public CreateCustomerCommandValidator()
        {
            RuleFor(x=>x.Model.Name).MinimumLength(3);
            RuleFor(x=>x.Model.LastName).MinimumLength(3);
            RuleFor(x=>x.Model.FavoriteList.Count).GreaterThan(0);
        }
    }
}