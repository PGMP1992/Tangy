using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tangy_DataAccess
{
    public class ProductPrice
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public required Product Product { get; set; }

        [MaxLength(50)]
        public required string Size { get; set; }

        public double Price { get; set; }
    }
}
