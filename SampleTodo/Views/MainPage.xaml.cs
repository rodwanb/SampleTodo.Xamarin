using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleTodo.ViewModels;
using SampleTodo.Models;
using SampleTodo.Views;

namespace SampleTodo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }

        async void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel && ListView.SelectedItem is Todo selectedTodo)
            {
                viewModel.SelectItem(selectedTodo);
            }
            await this.Navigation.PushAsync(new ContactDetailsPage());
        }

        void OnDeleteClicked(object sender, System.EventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel &&
                sender is MenuItem menuItem &&
                menuItem.CommandParameter is Todo selectedTodo)
            {
                viewModel.DeleteCommand.Execute(selectedTodo);
            }
        }
    }
}
