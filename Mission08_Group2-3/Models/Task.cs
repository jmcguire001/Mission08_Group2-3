using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Group2_3.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter a Task")]
        public string TaskName { get; set; }

        public string? DueDate { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
        
        public bool? Completed { get; set; }

        [Required(ErrorMessage = "Please enter a Quadrant between 1 and 4")]
        public int Quadrant { get; set; }
    }
}
