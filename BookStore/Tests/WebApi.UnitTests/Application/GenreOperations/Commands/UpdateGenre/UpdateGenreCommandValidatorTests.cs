using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command=new UpdateGenreCommand(null);
            command.GenreId=1;
            command.Model=new UpdateGenreModel(){ Name=genreName};

            UpdateGenreCommandValidator validations=new UpdateGenreCommandValidator();
            var result=validations.Validate(command);
            
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            UpdateGenreCommand command=new UpdateGenreCommand(null);
            command.GenreId=1;
            command.Model=new UpdateGenreModel(){ Name="WhenValidInputAreGiven_Validator_ShouldNotBeReturnErrors"};

            UpdateGenreCommandValidator validations=new UpdateGenreCommandValidator();
            var result=validations.Validate(command);
            
            result.Errors.Count.Should().Be(0);
        }
    }
}