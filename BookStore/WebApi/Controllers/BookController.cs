using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.DbOperations;


namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context){
            _context=context;
        }
 
        [HttpGet]
        public IActionResult GetBooks(){
            GetBookQuery query= new GetBookQuery(_context);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id){
            BookDetailViewModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context);
            try{
                query.BookId=id;
                result=query.Handle();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newbook){
            CreateBookCommand command =new CreateBookCommand(_context);
            try
            {
                command.Model=newbook;
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
            var book=_context.Books.SingleOrDefault(x=>x.Id==id);
            if(book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();

        }
    }
}