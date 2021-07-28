using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;

namespace Webapi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int DirectorId;
        public GetDirectorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public DirectorDetailModel Handle(){
            var director=_context.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if(director == null)
                throw new InvalidOperationException("Yönetmen bulunamadı");

            var result =_mapper.Map<DirectorDetailModel>(director);
            var movies=_context.Movies.Where(x=>x.DirectorId==DirectorId);
            foreach(var i in movies)
                result.Movies.Add(i.Name);
            
            return result;
        }
    }
    public class DirectorDetailModel{
        public string Name{get;set;}
        public string LastName{get;set;}
        public bool isActive{get;set;}=true;
        public virtual List<string> Movies{get;set;}
    }
}