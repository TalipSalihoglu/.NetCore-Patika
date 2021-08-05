using System;

namespace Webapi.Entities{
    public class Order{
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }=DateTime.Now.Date;
        public bool isActive { get; set; }=true;
    }
}