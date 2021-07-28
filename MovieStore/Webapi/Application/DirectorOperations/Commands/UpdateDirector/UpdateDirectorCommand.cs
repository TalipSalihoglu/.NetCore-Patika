using System;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;

namespace Webapi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        public UpdateDirectorModel Model{get;set;}
        public int DirectorId;
        public UpdateDirectorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var director=_context.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if(director==null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            
            director.Name=Model.Name!=default?Model.Name:director.Name;
            director.LastName=Model.LastName!=default?Model.LastName:director.LastName;
            director.isActive=Model.isActive!=default?Model.isActive:director.isActive;
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
        public bool isActive{get;set;}
    }
}