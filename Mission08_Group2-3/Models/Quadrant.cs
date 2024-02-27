using System.ComponentModel.DataAnnotations;

namespace Mission08_Group2_3.Models
{
    public class Quadrant
    {
        [Key]
        public int QuadrantId { get; set; }
        public string? QuadrantName { get; set;}
    }
}
