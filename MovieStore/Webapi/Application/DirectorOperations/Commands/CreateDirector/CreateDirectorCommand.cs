using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model{get;set;}
        public CreateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var director=_context.Directors.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if(director!=null)
                throw new InvalidOperationException("Bu yönetmen zaten kayıtlı.");
            
            var result=_mapper.Map<Director>(Model);
            _context.Directors.Add(result);
            _context.SaveChanges();
            /*
                !!!! Filmler kayıt edilirken directorId zorunlu olduğu için bu alana gerek yoktur. Önce yönetmen oluşturulur ve filmler
                     daha sonra bu yönetmen ile ilişkilendirilerek oluşturulur.
                  
                int newDirectorId=_context.Directors.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName).Id;
                foreach(var i in Model.Movies)
                {
                    _context.Movies.SingleOrDefault(x=>x.Id==i).DirectorId=newDirectorId;
                }
            */
        }
    }

    public class CreateDirectorModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
    }
}