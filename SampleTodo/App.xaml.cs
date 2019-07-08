using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using SampleTodo.Middlewares;
using SampleTodo.Actions;

namespace SampleTodo
{
    public partial class App : Application
    {
        // to be registered with ioc
        public static Store Store { get; } = new Store();

        private readonly List<object> middlewares = new List<object>();


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            //new up middlewares because ioc not setup as yet
            middlewares.Add(new LoggerMiddleware());
            middlewares.Add(new SaveStateMiddleware());
            middlewares.Add(new LoadStateMiddleware());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Store.Dispatch(new LoadStateAction());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
