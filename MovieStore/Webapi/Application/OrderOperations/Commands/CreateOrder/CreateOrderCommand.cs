using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.OrderOpearations.Commands.CreateOrder{
    public class CreateOrderCommand{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model;
        public CreateOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var isExistMovie=_context.Movies.SingleOrDefault(x=>x.Id==Model.MovieId);
            var isExistCustomer=_context.Customers.SingleOrDefault(x=>x.Id==Model.CustomerId);
            if(isExistCustomer is null || isExistMovie is null)
                throw new InvalidOperationException("Geçersiz şipariş. Sipariş yapılamadı");
                
            var order=_mapper.Map<Order>(Model);
            order.Price=_context.Movies.SingleOrDefault(x=>x.Id==order.MovieId).Price;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
    public class CreateOrderModel{
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        //public decimal Price { get; set; }
    }
}