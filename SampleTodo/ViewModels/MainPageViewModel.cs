using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;
using SampleTodo.Actions;
using SampleTodo.Extensions;
using SampleTodo.Models;
using Xamarin.Forms;

namespace SampleTodo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Todo> Todos { get; } = new ObservableCollection<Todo>();

        public ICommand AddCommand { get; }

        public ICommand DeleteCommand { get; }


        private string _newTodoTitle;
        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set
            {
                _newTodoTitle = value;
                OnPropertyChanged("NewTodoTitle");
            }
        }

        public MainPageViewModel()
        {
            AddCommand = new Command(OnAddCommand);
            DeleteCommand = new Command(OnDeleteCommand);

            App.Store.State
                .DistinctUntilChanged(x => new { x.TodoState.Todos })
                .Select(x => x.TodoState) // only interested in todoState
                .Where(x => x != null) // null check
                .ObserveOn(SynchronizationContext.Current) // main thread
                .Subscribe(state =>
                {
                    NewTodoTitle = string.Empty;
                    Todos.Clear();
                    foreach (var todo in state.Todos)
                    {
                        Todos.Add(todo);
                    }
                })
                .DisposeWith(Observers);
        }

        void OnAddCommand(object obj)
        {
            App.Store.Dispatch(new AddTodoAction(new Todo
            {
                Title = _newTodoTitle
            }));
        }

        public void SelectItem(Todo todo)
        {
            App.Store.Dispatch(new SelectTodoAction(todo));
        }

        void OnDeleteCommand(object obj)
        {
            if (obj is Todo todo)
            {
                App.Store.Dispatch(new RemoveTodoAction(todo.Id));
            }
        }
    }
}
