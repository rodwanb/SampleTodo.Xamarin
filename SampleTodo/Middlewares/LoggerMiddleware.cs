using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading;
namespace SampleTodo.Middlewares
{
    public class LoggerMiddleware
    {
        public LoggerMiddleware()
        {
            App.Store.Actions
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(action =>
                {
                    Debug.WriteLine($"Action: { action.GetType().Name }");
                });
        }
    }
}
