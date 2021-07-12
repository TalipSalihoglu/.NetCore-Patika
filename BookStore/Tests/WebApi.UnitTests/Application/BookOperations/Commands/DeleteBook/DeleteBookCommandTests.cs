using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Fact]
        public void WhenNotExistBookIsGiven__InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=500;// Not exist BookId

             FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
        }

         [Fact]
        public void WhenExistBookIsGiven_Book_ShouldBeRemove()
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=1;//Exist BookId

             FluentActions
                    .Invoking(()=> command.Handle()).Invoke();

            var book=_context.Books.SingleOrDefault(x=>x.Id==command.BookId);
            book.Should().BeNull();         
        }
    }
}