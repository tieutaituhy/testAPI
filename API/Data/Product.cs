using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Describe { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public byte SaleOf { get; set; }

        public int? TypeId { get; set; }
        [ForeignKey("TypeId")]
        public TypeProduct TypeProduct {get; set;}

        public ICollection<DetailOrder> DetailOrders { get; set; }
        public Product()
        {
            DetailOrders = new List<DetailOrder>();
        }
    }
}
