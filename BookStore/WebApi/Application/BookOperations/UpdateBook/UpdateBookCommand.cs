using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.UpdateBook{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId{get;set;}
        public UpdateBookModel model{get;set;}
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var book =_dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamad─▒");

            book.GenreId= model.GenreId != default ? model.GenreId:book.GenreId;
            book.AuthorId= model.AuthorId != default ? model.AuthorId:book.AuthorId;
            book.PageCount= model.PageCount != default ? model.PageCount:book.PageCount;
            book.PublishDate= model.PublishDate != default ? model.PublishDate:book.PublishDate;
            book.Title= model.Title != default ? model.Title:book.Title;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
}