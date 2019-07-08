using System;
using System.Reactive.Linq;
using System.Threading;
using SampleTodo.Extensions;
using System.Windows.Input;
using Xamarin.Forms;
using SampleTodo.Actions;

namespace SampleTodo.ViewModels
{
    public class ContactDetailsViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _id;

        public ICommand DeleteCommand { get; }

        public ContactDetailsViewModel()
        {
            DeleteCommand = new Command(OnDeleteCommand);

            App.Store.State
                .ObserveOn(SynchronizationContext.Current)
                .Select(x => x.TodoState.SelectedTodo)
                .Where(x => x != null)
                .Subscribe(state =>
                {
                    _id = state.Id;
                    Title = state.Title;
                    Description = state.Description;
                })
                .DisposeWith(Observers);
        }

        void OnDeleteCommand(object obj)
        {
            App.Store.Dispatch(new RemoveTodoAction(_id));
        }

    }
}
