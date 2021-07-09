using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book=new Book(){Title="WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",PageCount=100,GenreId=1,AuthorId=1,PublishDate=new DateTime(2020,01,02)};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel(){Title=book.Title};

            FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");
        }
        [Fact]
         public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
         {
             CreateBookCommand command=new CreateBookCommand(_context,_mapper);
             var model=new CreateBookModel(){Title="BookTitle",PageCount=100,GenreId=1,AuthorId=1,PublishDate=new DateTime(2020,01,02)};
             command.Model=model;

             FluentActions
                    .Invoking(()=>command.Handle()).Invoke();
            var book=_context.Books.SingleOrDefault(x=>x.Title==model.Title);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
            book.PublishDate.Should().Be(model.PublishDate);
         }
    }
}