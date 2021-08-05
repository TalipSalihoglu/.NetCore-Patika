using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace Webapi.Application.OrderOpearations.Queries.GetOrder{
    public class GetOrderQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OrderViewModel> Handle(){
            var orders=_context.Orders.Include(x=>x.Movie).Include(x=>x.Customer).Where(x=>x.isActive).OrderBy(x=>x.Id).ToList<Order>();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
    }
    public class OrderViewModel{
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
    } 
}
