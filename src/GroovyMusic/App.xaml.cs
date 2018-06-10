using GroovyMusic.DAL;
using GroovyMusic.DAL.SQLIte;
using GroovyMusic.Interfaces;
using GroovyMusic.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GroovyMusic
{
	public partial class App
	{
	    public static IDataLayer Database;

	    private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
	    }

	    private static void InitializeDatabase()
	    {
            Database = new SQLiteDataLayer(string.Empty);
	    }

        public App ()
		{
			InitializeComponent();
            
            InitializeLocalization();

            InitializeDatabase();

            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}
	}
}
