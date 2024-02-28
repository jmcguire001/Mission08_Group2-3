namespace Mission08_Group2_3.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
    }
}