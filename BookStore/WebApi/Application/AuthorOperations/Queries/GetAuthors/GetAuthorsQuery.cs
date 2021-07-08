using WebApi.DbOperations;
using System;
using System.Linq;
using WebApi.Entities;
using System.Collections.Generic;
using AutoMapper;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var list =_context.Authors.OrderBy(x=>x.Id).ToList<Author>();
            return _mapper.Map<List<AuthorsViewModel>>(list);
        }
    }
    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate {get;set;}
    }
}