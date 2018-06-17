using GroovyMusic.DI;
using GroovyMusic.Interfaces;
using GroovyMusic.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GroovyMusic
{
	public partial class App
	{
        private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
	    }
        
        public App ()
		{
			InitializeComponent();

            InitializeLocalization();

            MainPage = new MainPage();
		}
	}
}