using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.DirectorOperations.Commands.CreateDirector;
using Webapi.Application.DirectorOperations.Commands.DeleteDirector;
using Webapi.Application.DirectorOperations.Commands.UpdateDirector;
using Webapi.Application.DirectorOperations.Queries;
using Webapi.Application.DirectorOperations.Queries.GetDirectorDetail;
using Webapi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors(){
            GetDirectorQuery query=new GetDirectorQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetMovies(int id){
            GetDirectorDetailQuery query=new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorId=id;

            GetDirectorDetailQueryValidator validations=new GetDirectorDetailQueryValidator();
            validations.ValidateAndThrow(query);

            var result=query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector){
            CreateDirectorCommand command=new CreateDirectorCommand(_context,_mapper);
            command.Model=newDirector;

            CreateDirectorCommandValidator validations=new CreateDirectorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id,[FromBody] UpdateDirectorModel updateDirector){
            UpdateDirectorCommand command= new UpdateDirectorCommand(_context);
            command.DirectorId=id;
            command.Model=updateDirector;

            UpdateDirectorCommandValidator validations=new UpdateDirectorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
         }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command=new DeleteDirectorCommand(_context);
            command.DirectorId=id;

            DeleteDirectorCommandValidator validations=new DeleteDirectorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}