using System.Collections.Generic;

namespace SalesManager.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderDetail> Items { get; set; }
    }
}
