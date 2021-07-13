using TestSetup;
using Xunit;
using WebApi.DbOperations;
using AutoMapper;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Entities;
using FluentAssertions;
using System;
using System.Linq;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            Genre genre=new Genre(){Name="WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturn"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command =new CreateGenreCommand(_context,_mapper);
            command.Model=new CreateGenreModel(){Name=genre.Name};
            
            FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten kayıtlı.");
        }

        [Fact]
         public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
         {
             CreateGenreCommand command=new CreateGenreCommand(_context,_mapper);
             var model=new CreateGenreModel(){Name="TestGenreName"};
             command.Model=model;

             FluentActions
                    .Invoking(()=>command.Handle()).Invoke();

            var genre=_context.Genres.SingleOrDefault(x=>x.Name==model.Name);
            genre.Should().NotBeNull();

         }
    }
}