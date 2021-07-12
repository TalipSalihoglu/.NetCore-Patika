using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command =new UpdateBookCommand(_context);
            command.BookId=100;
            
             FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");
        }

        [Fact]
         public void WhenValidInputsAreGiven_Book_ShouldBeUpdate()
         {
            UpdateBookCommand command =new UpdateBookCommand(_context);
            command.BookId=3;
            UpdateBookModel bookModel= new UpdateBookModel(){Title="Test",PageCount=100,GenreId=1,AuthorId=1,PublishDate=new DateTime(2020,01,02)};

            command.model=bookModel;

             FluentActions
                    .Invoking(()=>command.Handle()).Invoke();
            var book=_context.Books.SingleOrDefault(x=>x.Id==command.BookId);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(bookModel.PageCount);
            book.GenreId.Should().Be(bookModel.GenreId);
            book.AuthorId.Should().Be(bookModel.AuthorId);
            book.PublishDate.Should().Be(bookModel.PublishDate);
            
            
         }
    }
}