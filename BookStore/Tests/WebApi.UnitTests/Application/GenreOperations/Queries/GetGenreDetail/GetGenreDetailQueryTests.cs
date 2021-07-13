using System;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public GetGenreDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery command=new GetGenreDetailQuery(_context,null);
            command.GenreId=1000;//not exist

             FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }
    }
}