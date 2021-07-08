using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DbOperations;
using WebApi.Application.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper){
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
            
            query.BookId=id;
            GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
           
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newbook){
            
            CreateBookCommand command =new CreateBookCommand(_context,_mapper);

            command.Model=newbook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            command.model=updatedBook;
            command.BookId=id;
            UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
          
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command =new DeleteBookCommand(_context);
            command.BookId=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
    
            return Ok();

        }
    }
}