using backend.Core.Events;
using backend.Core.Interfaces;

namespace backend.Core.Entities
{
    public class ToDoItem 
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;

        }

        public override string ToString()
        {
            string status = IsDone ? "Done!" : "Not done.";
            return $"{""}: Status: {status} - {Title} - {Description}";
        }
    }
}
