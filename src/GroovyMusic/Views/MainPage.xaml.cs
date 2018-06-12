using System;

using GroovyMusic.ViewModels;

using Xamarin.Forms;

namespace GroovyMusic.Views
{
	public partial class MainPage : ContentPage
	{
	    private MainPageViewModel viewModel => (MainPageViewModel) BindingContext;

		public MainPage()
		{
			InitializeComponent();

		    BindingContext = new MainPageViewModel();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

            viewModel.LoadData();
	    }

	    public void OnFilterChanged(object sender, EventArgs e)
	    {
	        cvMain.Content = viewModel.SelectedFilter.View;
	    }
    }
}