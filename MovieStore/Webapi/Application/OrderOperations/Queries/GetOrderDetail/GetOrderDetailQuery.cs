using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.OrderOpearations.Queries.GetOrderDetail{
    public class GetOrderDetailQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId;
        public GetOrderDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public OrderDetailViewModel Handle(){
            var order=_context.Orders.Include(x=>x.Movie).Include(x=>x.Customer).SingleOrDefault(x=>x.Id==OrderId);
            if(order is null)
                throw new InvalidOperationException("Sipariş bulunamdı");
                
            return _mapper.Map<OrderDetailViewModel>(order);
        }
    }
    public class OrderDetailViewModel{
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public bool isActive { get; set; }
    } 
}
