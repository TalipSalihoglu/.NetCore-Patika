using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.DbOperations;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper){
            _context=context;
            _mapper=mapper;
        }
 
        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query= new GetBooksQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id){
            BookDetailViewModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
            try{
                query.BookId=id;
                GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result=query.Handle();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newbook){
            CreateBookCommand command =new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model=newbook;
                CreateBookCommandValidator validator=new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            try{
                command.model=updatedBook;
                command.BookId=id;
                UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command =new DeleteBookCommand(_context);
            try{
                command.BookId=id;
                DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }
    }
}