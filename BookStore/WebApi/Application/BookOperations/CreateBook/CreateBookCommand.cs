using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly  IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper=mapper;
        }

        public void Handle()
        {
            var book= _dbContext.Books.SingleOrDefault(x=>x.Title== Model.Title);
            if(book!=null)
                throw new InvalidOperationException("Kitap zaten mevcut.");
            book=_mapper.Map<Book>(Model);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
     public class CreateBookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
            public int AuthorId{get;set;}
        }
}