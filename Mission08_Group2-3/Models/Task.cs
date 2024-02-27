using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Group2_3.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? DueDate { get; set; }

        [ForeignKey("QuadrantId")]
        public int QuadrantId { get; set; } // Foreign key
        public Quadrant? Quadrant { get; set; } // Navigation properties

        [ForeignKey("Category")]
        public int CategoryId { get; set; } // Foreign key
        public Category? Category { get; set; } // Navigation properties


        public bool Completed { get; set; }

    }
}
