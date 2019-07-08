using System;
using SampleTodo.Models;
using SampleTodo.Actions;
using System.Linq;
using Xamarin.Forms.Internals;

namespace SampleTodo.Reducers
{
    public class ApplicationReducer
    {
        public static ApplicationState Reduce(ApplicationState state, AppAction action)
        {
            if (action is LoadStateSuccessful loadStateSuccessful)
            {
                return loadStateSuccessful.ApplicationState;
            }

            return new ApplicationState
            {
                TodoState = TodoReducer.Reduce(state.TodoState, action)
            };
        }
    }

    public class TodoReducer
    {
        public static TodoState Reduce(TodoState state, AppAction action)
        {
            return new TodoState
            {
                Todos = ReduceTodos(state.Todos, action),
                Busy = ReduceBusy(state.Busy, action),
                SelectedTodo = ReduceSelectedTodo(state.SelectedTodo, action)
            };
        }

        private static Todo[] ReduceTodos(Todo[] state, AppAction action)
        {
            switch (action)
            {
                case AddTodoAction addTodo:
                    if (string.IsNullOrEmpty(addTodo.Todo.Title))
                    {
                        return state;
                    }
                    else
                    {
                        addTodo.Todo.Id = Guid.NewGuid().ToString();
                        return state
                            .Concat(new[] { addTodo.Todo })
                            .ToArray();
                    }
                case RemoveTodoAction removeTodo:
                    return state
                        .Where(x => x.Id != removeTodo.Id)
                        .ToArray();
                case EditTodoAction editTodo:
                    var todoToEditIndex = state.IndexOf(x => x.Id == editTodo.Id);
                    if (todoToEditIndex != -1)
                    {
                        state[todoToEditIndex] = editTodo.Todo;
                    }
                    return state;
                default:
                    return state;
            }
        }

        private static bool ReduceBusy(bool state, AppAction action)
        {
            //TODO
            return state;
        }

        private static Todo ReduceSelectedTodo(Todo state, AppAction action)
        {
            if (action is SelectTodoAction selectTodo)
            {
                return selectTodo.Todo;
            }

            return state;
        }
    }
}
