using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Queries.GetBookDetail
{    
    public class GetBookDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetBookDetailQuery command=new GetBookDetailQuery(_context,null);
            command.BookId=1000;//not exist

             FluentActions
                    .Invoking(()=> command.Handle())
                    .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
        }
    }
}