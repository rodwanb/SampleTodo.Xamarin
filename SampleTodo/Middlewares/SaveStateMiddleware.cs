using System;
using System.Reactive.Linq;
using System.Threading;
using Newtonsoft.Json;
using Xamarin.Essentials;
using SampleTodo.Actions;

namespace SampleTodo.Middlewares
{
    public class SaveStateMiddleware
    {
        public SaveStateMiddleware()
        {
            App.Store.Actions
                .Where(x => !(x is LoadStateAction) && !(x is LoadStateSuccessful))
                .ObserveOn(SynchronizationContext.Current)
                .Select(_ => App.Store.GetState())
                .Subscribe(state =>
                {
                    var serializedState = JsonConvert.SerializeObject(state);
                    Preferences.Set("state", serializedState);
                });
        }
    }
}
