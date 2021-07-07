using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorModel Model{get;set;}
        public int AuthorId;
        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamdı.");
            
            author.Name= Model.Name != default ? Model.Name : author.Name;
            author.LastName= Model.LastName != default ? Model.LastName : author.LastName;
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}