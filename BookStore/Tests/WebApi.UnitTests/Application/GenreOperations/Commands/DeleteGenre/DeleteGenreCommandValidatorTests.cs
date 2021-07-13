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
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1000)]
        public void WhenInvalidGenreIdAreGiven_Validator_ShouldBeReturnErrors(int GenreId)
        {
            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreId=GenreId;

            DeleteGenreCommandValidator validations=new DeleteGenreCommandValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}