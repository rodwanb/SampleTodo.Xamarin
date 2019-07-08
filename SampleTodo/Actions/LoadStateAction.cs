using SampleTodo.Models;
namespace SampleTodo.Actions
{
    public class LoadStateAction : AppAction
    {

    }

    public class LoadStateSuccessful : AppAction
    {
        public ApplicationState ApplicationState { get; }

        public LoadStateSuccessful(ApplicationState applicationState)
        {
            ApplicationState = applicationState;
        }
    }
}
