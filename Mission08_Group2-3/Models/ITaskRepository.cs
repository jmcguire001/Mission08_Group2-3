namespace Mission08_Group2_3.Models
{
    public interface ITaskRepository // Interface which is a template for all of the classes. 
    {
        
        List<Task> Tasks { get; } // List containing items of type 'Task'
        List<Category> Categories { get; } // List containing items of type 'Category'

        
        public void AddTask(Task task); //Method that takes parameter of task of type 'Task' and returns nothing. Classes implementing this interface are required to define how to add a Task object

        public void UpdateTask(Task task); // Method for updating tasks to the views (This is for when the user edits)

        public void DeleteTask(Task task); // Method for deleting tasks from the views (This is for when the user deletes)
    }
}