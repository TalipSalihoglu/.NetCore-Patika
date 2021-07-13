using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.CreateGenre
{    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public CreateGenreCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string _name)
        {
            CreateGenreCommand command=new CreateGenreCommand(null,null);
            command.Model=new CreateGenreModel(){ Name=_name};

            CreateGenreCommandValidator validations=new CreateGenreCommandValidator();
            var result=validations.Validate(command);
            
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateGenreCommand command=new CreateGenreCommand(null,null);
            command.Model=new CreateGenreModel(){ Name="WhenValidInputAreGiven_Validator_ShouldNotBeReturnError"};

            CreateGenreCommandValidator validations=new CreateGenreCommandValidator();
            var result=validations.Validate(command);
            
            result.Errors.Count.Should().Be(0);
        }
    }
}