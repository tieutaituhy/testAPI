namespace API.Model
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public Double Price { get; set; }
    }
    public class Product: ProductVM
    {
        public Guid ProductId { get; set; }
    }

    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Double Price { get; set; }
        public string NameType { get; set; }
    }
}
