using WebApi.DbOperations;
using System.Linq;
using System;
namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId {get;set;}
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var Author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(Author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");
            
            var anyBook=_context.Books.Any(x=>x.AuthorId==AuthorId);
            if(anyBook)
                throw new InvalidOperationException("Bu yazara ait kitap bulunmaktadır, önce o kitaplar silinmelidir.");

            _context.Authors.Remove(Author);
            _context.SaveChanges();
        }
    }
}