using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public GetBookDetailQueryValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int BookId)
        {
            GetBookDetailQuery command=new GetBookDetailQuery(_context,null);
            command.BookId=BookId;

            GetBookDetailQueryValidator validations=new GetBookDetailQueryValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldBeNotReturnErrors()
        {
            GetBookDetailQuery command=new GetBookDetailQuery(_context,null);
            command.BookId=1;

            GetBookDetailQueryValidator validations=new GetBookDetailQueryValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}