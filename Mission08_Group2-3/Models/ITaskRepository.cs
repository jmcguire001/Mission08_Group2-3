namespace ScaffoldingFun.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
    }
}