using System;
using System.Linq;
using Webapi.DbOperations;

namespace Webapi.Application.OrderOpearations.Commands.DeleteOrder{
    public class DeleteOrderCommand{
        private readonly MovieStoreDbContext _context;
        public int OrderId;
        public DeleteOrderCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var order=_context.Orders.SingleOrDefault(x=>x.Id==OrderId);
            if(order is null)
                throw new InvalidOperationException("Sipariş bulunamadı");
                
            order.isActive=false;
            _context.SaveChanges();
        }
    }
}