using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;

namespace Webapi.Application.DirectorOperations.Queries
{
    public class GetDirectorQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            var DirectorList=_context.Directors.Where(x=>x.isActive).ToList();
            return _mapper.Map<List<DirectorsViewModel>>(DirectorList);
        }
    }
    public class DirectorsViewModel{
        public string Name{get;set;}
        public string LastName{get;set;}
        public bool isActive{get;set;}
    }
}