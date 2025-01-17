using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tangy_Models
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        
        [Required]
        public int OrderHeaderId { get; set; }

        [Required]
        public int ProductId { get; set; }
        
        [NotMapped]
        public virtual ProductDTO Product { get; set; }

        [Required]
        public int Count { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        public string Size { get; set; }
        
        [Required]
        public string ProductName { get; set; }
    }
}
