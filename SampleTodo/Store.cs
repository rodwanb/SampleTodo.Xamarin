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
        // incoming pipeline for state changes
        private readonly BehaviorSubject<ApplicationState> _stateSubject = new BehaviorSubject<ApplicationState>(ApplicationState.Initial());

        // incoming pipeline for actions
        private readonly BehaviorSubject<AppAction> _actionsSubject = new BehaviorSubject<AppAction>(new LoadStateAction());

        // outgoing pipeline for state changes
        public IObservable<ApplicationState> State => _stateSubject.AsObservable();

        // outgoing pipeline for actions
        public IObservable<AppAction> Actions => _actionsSubject.AsObservable();

        public Store()
        {
            //listens for incomming actions and then passes it through the reducer to act on the action then updates the state
            //the state then broadcasts the latest value to it's subscribers
            Actions.Subscribe(action => _stateSubject.OnNext(ApplicationReducer.Reduce(GetState(), action)));
        }

        public void Dispatch(AppAction action)
        {
            // adds action to pipeline
            _actionsSubject.OnNext(action);
        }

        // gets latest value in state pipeline
        public ApplicationState GetState() => _stateSubject.Value;
    }
}
