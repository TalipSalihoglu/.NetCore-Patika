using System;
using System.Linq;
using Webapi.DbOperations;

namespace Webapi.Application.OrderOpearations.Commands.UpdateOrder
{
    public class UpdateOrderCommand{
        private readonly MovieStoreDbContext _context;
        public int OrderId;
        public UpdateOrderModel Model;
        public UpdateOrderCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
           var order= _context.Orders.SingleOrDefault(x=>x.Id==OrderId);
           if(order is null){
               throw new InvalidOperationException("Şipariş bulunamadı");
           }
           order.CustomerId=Model.CustomerId!=default?Model.CustomerId:order.CustomerId;
           order.isActive=Model.isActive!=default?Model.isActive:order.isActive;
           _context.SaveChanges();
        }
    }
    public class UpdateOrderModel{
        public int CustomerId { get; set; }

        public bool isActive { get; set; }
    }
}