using FluentValidation;

namespace Webapi.Application.OrderOpearations.Queries.GetOrderDetail{
    public class GetOrderDetailQueryValidator:AbstractValidator<GetOrderDetailQuery>{
        public GetOrderDetailQueryValidator()
        {
            RuleFor(x=>x.OrderId).GreaterThan(0);    
        }
    }
}