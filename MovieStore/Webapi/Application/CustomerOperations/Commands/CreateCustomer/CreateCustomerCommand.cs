using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommand{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model;
        public CreateCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var customer =_context.Customers.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName);
            if(customer is not null)
                throw new InvalidOperationException("Müşteri zaten kayıtlı.");
            
            var result=_mapper.Map<Customer>(Model);
            _context.Customers.Add(result);
            _context.SaveChanges();
            int customerId =_context.Customers.SingleOrDefault(x=>x.Name==Model.Name && x.LastName==Model.LastName).Id;
            foreach(var i in Model.FavoriteList)
            {
                _context.FavoriteGenres.Add(new FavoriteGenre(){GenreId=i,CustomerId=customerId});
            }
            _context.SaveChanges();
        }

    }
    public class CreateCustomerModel{
        public string Name{get;set;}
        public string LastName { get; set; }
        public List<int> FavoriteList{get;set;}
    }
}