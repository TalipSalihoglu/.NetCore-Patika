using FluentValidation;

namespace Webapi.Application.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>{
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x=>x.CustomerId).GreaterThan(0);
        }
    }
}