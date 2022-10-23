namespace API.Data
{
    public class DetailOrder
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public byte SaleOf { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
