using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("Product")]
    public class TypeProduct
    {
        [Key]
        public int? TypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
