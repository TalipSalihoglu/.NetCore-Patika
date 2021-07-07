using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper){
            _context=context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query =new GetAuthorsQuery(_context,_mapper);
            var authors=query.Handle();
            return Ok(authors);
        }

        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query =new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId=id;

            GetAuthorDetailQueryValidator validations=new GetAuthorDetailQueryValidator();
            validations.ValidateAndThrow(query);

            var obj=query.Handle();
            return Ok(obj);

        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel author)
        {
            CreateAuthorCommand command=new CreateAuthorCommand(_context,_mapper);
            command.Model=author;

            CreateAuthorCommandValidator validations=new CreateAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command =new UpdateAuthorCommand(_context,_mapper);
            command.AuthorId=id;
            command.Model=updatedAuthor;
            
            UpdateAuthorCommandValidator validations=new UpdateAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId=id;
            DeleteAuthorCommandValidator validations=new DeleteAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}