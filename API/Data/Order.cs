using System;

namespace API.Data
{
    public enum StatusOrder
    {
        New = 0, Payment = 1, Conplete = 2, Cancel = 3
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public string Recipient { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<DetailOrder> DetailOrders { get; set; }
        public Order()
        {
            DetailOrders = new List<DetailOrder>();
        }
    }
}
