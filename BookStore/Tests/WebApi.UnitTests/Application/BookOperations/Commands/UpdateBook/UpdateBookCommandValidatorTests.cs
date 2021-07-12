using System;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Theory]
        [InlineData(" ",0,0,0)]
        [InlineData("test1",0,0,0)]
        [InlineData("test1",1,0,0)]
        [InlineData("test1",1,1,0)]
        [InlineData("t",1,0,0)]
        [InlineData("t",1,1,0)]
        [InlineData("t",1,1,1)]
        [InlineData("t",0,1,0)]
        [InlineData("t",0,1,1)]
        [InlineData("t",1,1,1)]
        [InlineData("t",0,0,1)]
        [InlineData("t",1,0,1)]
        [InlineData("t",1,1,1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int PageCount,int GenreId,int AuthorId)
        {
            UpdateBookCommand command=new UpdateBookCommand(null);
            command.model=new UpdateBookModel
            {
                Title=title,
                PageCount=PageCount,
                PublishDate=DateTime.Now.Date.AddYears(-1),
                GenreId=GenreId,
                AuthorId=AuthorId
            };
            
            UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
            var result=validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

         [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand command=new UpdateBookCommand(null);
            command.model=new UpdateBookModel
            {
                Title="title",
                PageCount=123,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=2,
                AuthorId=2
            };
            
            UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
            var result=validations.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}