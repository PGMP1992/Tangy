using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Category Category { get; set; }
        
        //public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
