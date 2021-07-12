using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int BookId)
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=BookId;

            DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=3;

            DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}