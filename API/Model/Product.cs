namespace API.Model
{
    public class ProductVM
    {
        public string ProductVMName { get; set; }
        public Double Price { get; set; }
    }
    public class Product: ProductVM
    {
        public Guid ProductId { get; set; }
    }
}
