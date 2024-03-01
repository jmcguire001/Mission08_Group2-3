namespace Mission08_Group2_3.Models
{
    public class EFTaskRepository : ITaskRepository // EFTaskRepository is implementing from ITaskRepository ("Inheriting")
    {
        private MatrixContext _context;

        public EFTaskRepository(MatrixContext temp) // Constructor that requires context file as input
        {
            _context = temp;
        }
        public List<Task> Tasks => _context.Tasks.ToList(); // Returning a list of 'Task' entities from the database

        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task) // Method is responsible for adding a new task to the database
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task) // Method is responsible for updating a tasks to the database
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task) // Method is responsible for removing tasks to from the database
        { 
            _context.Remove(task);
            _context.SaveChanges();
        }
    }
}