using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace SampleTodo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected List<IDisposable> Observers { get; } = new List<IDisposable>();

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public virtual void DisposeObservers()
        {
            Observers.ForEach(x => x.Dispose());
        }
    }
}
