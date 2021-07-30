using System;
using System.Linq;
using Webapi.DbOperations;

namespace Webapi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand{
        private readonly MovieStoreDbContext _context;
        public int ActorId;
        public DeleteActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var actor=_context.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if(actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı.");
            
            var movies=_context.MovieActors.Where(x=>x.ActorId==ActorId).ToList();
            if(movies.Count>0)
                throw new InvalidOperationException("Oyuncunun kayıtlı olduğu filmler var. Önce ilişkili filmler silinmelidir.");                
            
            actor.isActive=false;
            _context.SaveChanges();
        }
    }
}