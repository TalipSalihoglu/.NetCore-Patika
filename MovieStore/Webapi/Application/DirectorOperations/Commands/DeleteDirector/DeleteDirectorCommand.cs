using System.Linq;
using System;
using Webapi.DbOperations;

namespace Webapi.Application.DirectorOperations.Commands.DeleteDirector{
    public class DeleteDirectorCommand{
        private readonly MovieStoreDbContext _context;
        public int DirectorId;
        public DeleteDirectorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director =_context.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if(director==null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");

            director.isActive=false;
            _context.SaveChanges();
        }
    }
}