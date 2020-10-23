using backend.Core.Entities;

namespace backend.Core.Events
{
    public class ToDoItemCompletedEvent 
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}