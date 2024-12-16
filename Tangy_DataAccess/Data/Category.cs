using System.ComponentModel.DataAnnotations;

namespace Tangy_DataAccess.Data
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
