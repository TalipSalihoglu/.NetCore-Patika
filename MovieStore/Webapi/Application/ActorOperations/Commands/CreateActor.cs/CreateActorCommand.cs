using System;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model;
        public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var actor=_context.Actors.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if(actor is not null)
                throw new InvalidOperationException("Actor zaten kayıtlı.");
            
            var newActor=_mapper.Map<Actor>(Model);
            _context.Actors.Add(newActor);
            _context.SaveChanges();
        }
    }
    public class CreateActorModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
    }
}