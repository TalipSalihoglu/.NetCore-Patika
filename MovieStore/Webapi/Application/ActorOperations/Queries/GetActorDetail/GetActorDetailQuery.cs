using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.ActorOperations.Commands.Queries.GetActorDetail
{
    public class GetActorDetailQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int ActorId;
        public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ActorDetailModel Handle(){

            var actors=_context.Actors.SingleOrDefault(x=>x.Id==ActorId);
            var result= _mapper.Map<ActorDetailModel>(actors);

            var movies=_context.MovieActors.Include(x=>x.Movie).Where(x=>x.ActorId==ActorId).ToList();
            
            foreach(var i in movies)
                result.Movies.Add(i.Movie.Name);

            return result;
        }
    }
    public class ActorDetailModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
        public List<String> Movies{get;set;}
    }
}