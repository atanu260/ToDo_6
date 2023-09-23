using System.ComponentModel.DataAnnotations;

namespace WebApp1_6.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
    }
}
