using System;
using System.Reactive.Linq;
using System.Threading;
using Xamarin.Essentials;
using Newtonsoft.Json;
using SampleTodo.Actions;
using SampleTodo.Models;
namespace SampleTodo.Middlewares
{
    public class LoadStateMiddleware
    {
        public LoadStateMiddleware()
        {
            App.Store.Actions
                .Where(x => x is LoadStateAction)
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(action =>
                {
                    try
                    {
                        var serializedState = Preferences.Get("state", "");
                        var deserializedState = JsonConvert.DeserializeObject<ApplicationState>(serializedState);
                        if (deserializedState != null)
                        {
                            App.Store.Dispatch(new LoadStateSuccessful(deserializedState));
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: maybe dispatch exception action
                    }
                });
        }
    }
}
