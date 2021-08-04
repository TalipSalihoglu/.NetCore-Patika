
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.CustomerOperations.Commands.CreateCustomer;
using Webapi.Application.CustomerOperations.Commands.DeleteCustomer;
using Webapi.DbOperations;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel model){
            CreateCustomerCommand command= new CreateCustomerCommand(_context,_mapper);
            command.Model=model;

            CreateCustomerCommandValidator validations=new CreateCustomerCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerDetail(int id){
            GetCustomerDetailQuery query= new GetCustomerDetailQuery(_context,_mapper);
            query.CustomerId=id;

            GetCustomerDetailQueryValidator validations=new GetCustomerDetailQueryValidator();
            validations.ValidateAndThrow(query);

            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command=new DeleteCustomerCommand(_context);
            command.CustomerId=id;
            DeleteCustomerCommandValidator validations=new DeleteCustomerCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}