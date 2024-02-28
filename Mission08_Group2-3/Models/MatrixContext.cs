using Microsoft.EntityFrameworkCore;

namespace Mission08_Group2_3.Models
{
    public class MatrixContext : DbContext
    {
        public MatrixContext(DbContextOptions<MatrixContext> options) : base (options)
        { 
        
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
