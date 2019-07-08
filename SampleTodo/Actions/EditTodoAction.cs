using SampleTodo.Models;
namespace SampleTodo.Actions
{
    public class EditTodoAction : AppAction
    {
        public string Id { get; }
        public Todo Todo { get; }

        public EditTodoAction(string id, Todo todo)
        {
            Id = id;
            Todo = todo;
        }
    }
}
