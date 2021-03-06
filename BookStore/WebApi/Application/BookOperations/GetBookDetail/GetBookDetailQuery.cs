using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.GetBookDetail
{
   public class GetBookDetailQuery
   {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId;
        public GetBookDetailQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper=mapper;
        }
        public BookDetailViewModel Handle(){
            var book= _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).Where(x=>x.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamad─▒");

            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book);
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title{get;set;}
        public string Genre{get;set;}
        public string Author{get;set;}
        public int PageCount{get;set;}
        public string PublishDate{get;set;}   
    }
}