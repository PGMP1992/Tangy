using System.ComponentModel.DataAnnotations;
using Tangy_DataAccess;

namespace Tangy_Models
{
    public  class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool ShopFavorites { get; set; }

        public bool CustomerFavorites { get; set; }

        [MaxLength(50)]
        public string Color { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Category.")]
        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
