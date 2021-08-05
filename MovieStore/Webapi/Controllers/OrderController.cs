using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.OrderOpearations.Commands.CreateOrder;
using Webapi.Application.OrderOpearations.Commands.DeleteOrder;
using Webapi.Application.OrderOpearations.Queries.GetOrder;
using Webapi.Application.OrderOpearations.Queries.GetOrderDetail;
using Webapi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders(){
            GetOrderQuery query=new GetOrderQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id){
            GetOrderDetailQuery query=new GetOrderDetailQuery(_context,_mapper);
            query.OrderId=id;

            GetOrderDetailQueryValidator validations=new GetOrderDetailQueryValidator();
            validations.ValidateAndThrow(query);
            
            var result=query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel newOrder){
            CreateOrderCommand command=new CreateOrderCommand(_context,_mapper);
            command.Model=newOrder;

            CreateOrderCommandValidator validations=new CreateOrderCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id){
            DeleteOrderCommand command=new DeleteOrderCommand(_context);
            command.OrderId=id;

            DeleteOrderCommandValidator validations=new DeleteOrderCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateOrder(int id){
           
        //    //TODO

        // }
    }
}
