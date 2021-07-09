using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
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
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel
            {
                Title=title,
                PageCount=PageCount,
                PublishDate=DateTime.Now.Date.AddYears(-1),
                GenreId=GenreId,
                AuthorId=AuthorId
            };
            
            CreateBookCommandValidator validations=new CreateBookCommandValidator();
            var result=validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel
            {
                Title="title",
                PageCount=123,
                PublishDate=DateTime.Now.Date,
                GenreId=2,
                AuthorId=2
            };
            
            CreateBookCommandValidator validations=new CreateBookCommandValidator();
            var result=validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel
            {
                Title="title",
                PageCount=123,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=2,
                AuthorId=2
            };
            
            CreateBookCommandValidator validations=new CreateBookCommandValidator();
            var result=validations.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}