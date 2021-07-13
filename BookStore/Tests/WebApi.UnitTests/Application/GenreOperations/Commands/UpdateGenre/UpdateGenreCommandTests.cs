using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Fact]
        public void WhenNotExisGenreIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateGenreCommand command =new UpdateGenreCommand(_context);
            command.GenreId=500;//Not exist GenreId
            
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }

        [Fact]
         public void WhenValidInputsAreGiven_Genre_ShouldBeUpdate()
         {
            UpdateGenreCommand command =new UpdateGenreCommand(_context);
            command.GenreId=3;
            var genreModel= new UpdateGenreModel(){Name="WhenValidInputsAreGiven_Genre_ShouldBeUpdate"};

            command.Model=genreModel;

             FluentActions
                    .Invoking(()=>command.Handle()).Invoke();
            var genre=_context.Genres.SingleOrDefault(x=>x.Id==command.GenreId);

            genre.Should().NotBeNull();
            genre.Name.Should().Be(genreModel.Name);
            genre.IsActive.Should().Be(genreModel.IsActive);
         }
    }
}