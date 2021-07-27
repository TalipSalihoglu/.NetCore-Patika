using System;
using System.Linq;
using Webapi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie{
    public class DeleteMovieCommand{
        private readonly MovieStoreDbContext _context;
        public int MovieId{get;set;}
        public DeleteMovieCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var movie=_context.Movies.SingleOrDefault(x=>x.Id==MovieId);
            if(movie==null)
                throw new InvalidOperationException("Kayıtlı film bulunamadı");
            
            movie.isActive=false;
            _context.SaveChanges();
        }
    }
}