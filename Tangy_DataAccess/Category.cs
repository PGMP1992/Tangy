using System.ComponentModel.DataAnnotations;
//using Tangy_Models;


namespace Tangy_DataAccess
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        //public CategoryDTO MapToDto(Category category)
        //{
        //    return new CategoryDTO() 
        //    {
        //        Id = category.Id,
        //        Name = category.Name
        //    } 
        //}
    }
}
