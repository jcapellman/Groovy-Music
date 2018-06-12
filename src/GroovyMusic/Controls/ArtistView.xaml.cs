using GroovyMusic.Controls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroovyMusic.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArtistView : ContentView
	{
	    private ArtistViewModel viewModel => (ArtistViewModel) BindingContext;

		public ArtistView ()
		{
			InitializeComponent ();

		    BindingContext = new ArtistViewModel();
            
		    viewModel.LoadDataAsync();
        }
    }
}