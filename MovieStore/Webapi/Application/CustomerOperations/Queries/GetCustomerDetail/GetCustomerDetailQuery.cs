using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;
using WebApi.Common;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomerDetail{
    public class GetCustomerDetailQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId;
        public GetCustomerDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CustomerDetailViewModel Handle(){
            var customer=_context.Customers.SingleOrDefault(x=>x.Id==CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");

            var result = _mapper.Map<CustomerDetailViewModel>(customer);

            var fav=_context.FavoriteGenres.Where(x=>x.CustomerId==CustomerId);
            foreach(var i in fav)
            {
                result.FavoriteGenres.Add(((GenreEnum)i.GenreId).ToString());
            }

            var orders=_context.Orders.Include(x=>x.Movie).Where(x=>x.CustomerId==CustomerId);
            foreach(var i in orders)
            {
                result.Orders.Add(i.Movie.Name);
            }

            return result;
        }
        private string FullName(Actor actor){
            return actor.Name+" "+actor.LastName;
        }
    }
    public class CustomerDetailViewModel{
        public string Name{get;set;}
        public string LastName{get;set;}
        public bool isActive{get;set;}
        public List<String> FavoriteGenres{get;set;}
        public List<string> Orders{get;set;}
    }
}