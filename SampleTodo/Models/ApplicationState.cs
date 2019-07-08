using System;
namespace SampleTodo.Models
{
    public class ApplicationState
    {
        public TodoState TodoState { get; set; }

        public static ApplicationState Initial()
        {
            return new ApplicationState
            {
                TodoState = TodoState.Initial()
            };
        }
    }

    public class TodoState
    {
        public Todo[] Todos { get; set; }
        public Todo SelectedTodo { get; set; }
        public bool Busy { get; set; }

        public static TodoState Initial()
        {
            return new TodoState
            {
                Todos = new Todo[] { },
                Busy = false
            };
        }
    }
}
