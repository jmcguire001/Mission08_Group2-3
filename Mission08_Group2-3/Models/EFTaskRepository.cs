namespace ScaffoldingFun.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private MatrixContext _context;

        public EFTaskRepository(MatrixContext temp)
        {
            _context = temp;
        }
        public List<Task> Tasks => _context.Tasks.ToList();

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}