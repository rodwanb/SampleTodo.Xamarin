using System;
using System.Reactive.Subjects;
using SampleTodo.Models;
using SampleTodo.Actions;
using SampleTodo.Reducers;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using SampleTodo.Middlewares;
using System.Collections.Generic;

namespace SampleTodo
{
    public class Store
    {
        // pipeline for state changes
        public BehaviorSubject<ApplicationState> State { get; } = new BehaviorSubject<ApplicationState>(ApplicationState.Initial());

        // pipeline for actions
        // 
        public BehaviorSubject<AppAction> Actions { get; } = new BehaviorSubject<AppAction>(new LoadStateAction());

        public Store()
        {
            //listens for incomming actions and then passes it through the reducer to act on the action then updates the state
            //the state then broadcasts the latest value to it's subscribers
            Actions
                .Subscribe(action => State.OnNext(ApplicationReducer.Reduce(GetState(), action)));
        }

        public void Dispatch(AppAction action)
        {
            // adds action to pipeline
            Actions.OnNext(action);
        }

        // gets latest value in state pipeline
        public ApplicationState GetState() => State.Value;
    }
}
