namespace CloudSample.App.Web.Models
{
    public class TodoItem
    {
        public TodoItem(string name, bool isComplete = false)
        {
            Name = name;
            IsComplete = isComplete;
        }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
