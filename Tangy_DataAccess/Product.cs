using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tangy_DataAccess
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool ShopFavorites { get; set; }

        public bool CustomerFavorites { get; set; }

        [MaxLength(50)]
        public string Color { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }

        public required ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
