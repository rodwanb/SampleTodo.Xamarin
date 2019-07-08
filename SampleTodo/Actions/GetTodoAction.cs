namespace SampleTodo.Actions
{
    public class GetTodoAction : AppAction
    {
        public string Id { get; }

        public GetTodoAction(string id)
        {
            Id = id;
        }
    }
}
