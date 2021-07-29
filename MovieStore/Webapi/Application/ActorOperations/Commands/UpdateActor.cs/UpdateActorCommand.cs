using System;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand{
        private readonly MovieStoreDbContext _context;
        public UpdateActorModel Model;
        public int ActorId;
        public UpdateActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var actor=_context.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if(actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı.");
            
            actor.Name=Model.Name!=default?Model.Name:actor.Name;
            actor.LastName=Model.LastName!=default?Model.LastName:actor.LastName;
            actor.isActive=Model.isActive!=default?Model.isActive:actor.isActive;

            _context.SaveChanges();
        }
    }
    public class UpdateActorModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
         public bool isActive{get;set;}
    }
}