using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
   public class GetBookDetailQuery
   {
        private readonly BookStoreDbContext _dbContext;
        public int BookId;
        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public BookDetailViewModel Handle(){
            var book= _dbContext.Books.Where(x=>x.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulamadı");

            BookDetailViewModel vm=new BookDetailViewModel();
            vm.Title=book.Title;
            vm.PageCount=book.PageCount;
            vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy");
            vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title{get;set;}
        public string Genre{get;set;}
        public int PageCount{get;set;}
        public string PublishDate{get;set;}   
    }
}