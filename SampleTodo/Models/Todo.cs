using System;
namespace SampleTodo.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
