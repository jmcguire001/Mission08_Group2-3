using Microsoft.EntityFrameworkCore;

namespace Mission08_Group2_3.Models
{
    public class MatrixContext : DbContext
    {
        public MatrixContext(DbContextOptions<MatrixContext> options) : base (options)
        { 
        
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Quadrant> Quadrants { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Quadrant)
                .WithMany(q => q.Tasks)
                .HasForeignKey(t => t.QuadrantId);
        }

    }
}
