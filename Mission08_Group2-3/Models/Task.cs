using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Group2_3.Models
{
    // Task Model with corresponding keys to the other models
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required (ErrorMessage = "Task name required")]
        public string TaskName { get; set; }

        public string? DueDate { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
        
        public bool? Completed { get; set; }

        [Required(ErrorMessage = "Quadrant number required")]
        [Range(1, 4, ErrorMessage = "Quadrant value is between 1 and 4")]
        public int Quadrant { get; set; }
    }
}
