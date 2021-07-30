using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.ActorOperations.Commands.Queries.GetActors
{
    public class GetActorsQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetActorsQueryModel> Handle(){

            var actors=_context.Actors.Where(x=>x.isActive).ToList();
            return _mapper.Map<List<GetActorsQueryModel>>(actors);
        }
    }
    public class GetActorsQueryModel
    {
        public string Name{get;set;}
        public string LastName{get;set;}
    }
}