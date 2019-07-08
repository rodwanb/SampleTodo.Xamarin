using SampleTodo.Models;
namespace SampleTodo.Actions
{
    public class SelectTodoAction : AppAction
    {
        public Todo Todo { get; }

        public SelectTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }
}
