using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SampleTodo.ViewModels;

namespace SampleTodo.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage()
        {
            BindingContext = new ContactDetailsViewModel();
            InitializeComponent();
        }

        async void OnDeleteClicked(object sender, System.EventArgs e)
        {
            if (BindingContext is ContactDetailsViewModel viewModel)
            {
                viewModel.DeleteCommand.Execute(null);
            }
            await Navigation.PopAsync(true);
        }
    }
}
