using System;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public GetGenreDetailQueryValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int GenreId)
        {
            GetGenreDetailQuery command=new GetGenreDetailQuery(_context,null);
            command.GenreId=GenreId;

            GetGenreDetailQueryValidator validations=new GetGenreDetailQueryValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldBeNotReturnErrors()
        {
             GetGenreDetailQuery command=new GetGenreDetailQuery(_context,null);
            command.GenreId=2;

            GetGenreDetailQueryValidator validations=new GetGenreDetailQueryValidator();
            var result =validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}