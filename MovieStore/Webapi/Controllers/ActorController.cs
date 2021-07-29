using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.ActorOperations.Commands.CreateActor;
using Webapi.Application.ActorOperations.Commands.Queries.GetActorDetail;
using Webapi.Application.ActorOperations.Commands.Queries.GetActors;
using Webapi.Application.ActorOperations.Commands.UpdateActor;
using Webapi.DbOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetActionResult(){
            GetActorsQuery query=new GetActorsQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActionResult(int id){
            GetActorDetailQuery query=new  GetActorDetailQuery(_context,_mapper);
            query.ActorId=id;

            GetActorDetailQueryValidator validations=new GetActorDetailQueryValidator();
            validations.ValidateAndThrow(query);
            
            var result=query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel model){
            CreateActorCommand command=new  CreateActorCommand(_context,_mapper);
            command.Model=model;

            CreateActorCommandValidator validations=new CreateActorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

         [HttpPut("{id}")]
        public IActionResult UpdateActor(int id,[FromBody] UpdateActorModel updateActor){
            UpdateActorCommand command= new UpdateActorCommand(_context);
            command.ActorId=id;
            command.Model=updateActor;

            UpdateActorCommandValidator validations=new UpdateActorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
         }
    }
}