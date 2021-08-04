using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommand{
        private readonly MovieStoreDbContext _context;
        public int CustomerId;
        public DeleteCustomerCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var customer =_context.Customers.SingleOrDefault(x=>x.Id==CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");
            
            customer.isActive=false;
            _context.SaveChanges();
        }

    }
}