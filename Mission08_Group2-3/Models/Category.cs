using System.ComponentModel.DataAnnotations;

namespace Mission08_Group2_3.Models
{
    // Category model
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
