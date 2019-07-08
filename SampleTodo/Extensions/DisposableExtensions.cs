using System;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace SampleTodo.Extensions
{
    public static class DisposableExtensions
    {
        public static void DisposeWith(this IDisposable disposable, IList<IDisposable> disposables)
        {
            disposables.Add(disposable);
        }
    }
}
