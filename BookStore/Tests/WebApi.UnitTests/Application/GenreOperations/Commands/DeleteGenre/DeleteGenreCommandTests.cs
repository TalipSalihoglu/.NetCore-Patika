using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
                
            DeleteGenreCommand command =new DeleteGenreCommand(_context);
            command.GenreId=1000;//not exist GenreId
                
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }

        [Fact]
        public void WhenValidtGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // var genre=new Genre(){Id=12,Name="DeleteTestGenre",IsActive=true};
            // _context.Genres.Add(genre);
            // _context.SaveChanges();

            DeleteGenreCommand command =new DeleteGenreCommand(_context);
            command.GenreId=1;// exist GenreId
                
            FluentActions
                .Invoking(()=> command.Handle()).Invoke();
            
            var _genre=_context.Genres.SingleOrDefault(x=>x.Id==command.GenreId);
            _genre.IsActive.Should().Be(false);
            
        }
    }
}

