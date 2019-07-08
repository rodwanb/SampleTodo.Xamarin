namespace SampleTodo.Actions
{
    public class RemoveTodoAction : AppAction
    {
        public string Id { get; }

        public RemoveTodoAction(string id)
        {
            Id = id;
        }
    }
}
