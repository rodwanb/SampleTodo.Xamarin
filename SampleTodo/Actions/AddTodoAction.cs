using SampleTodo.Models;
namespace SampleTodo.Actions
{
    public class AddTodoAction : AppAction
    {
        public Todo Todo { get; }

        public AddTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }
}
